using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.Highheel.Plugin.Core
{
    public static class Hooks
    {
        private static readonly float[] ToeX = { 0f, 0f, 0f, 0f, 0f, 0f };
        private static readonly Dictionary<TBody, MaidTransforms> MaidTransforms = new();
        private static readonly Dictionary<TBody, string> ShoeConfigs = new();
        private static string currentSceneName;

        // Subscribe to scene loaded event to update the cached scene index
        static Hooks()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            currentSceneName = scene.name;
        }

        //<summary>
        // This method is called when the item is put on.
        //</summary>
        [HarmonyPostfix]
        [HarmonyPatch(typeof(TBodySkin),
            nameof(TBodySkin.Load),
            typeof(MPN),
            typeof(Transform),
            typeof(Transform),
            typeof(Dictionary<string, Transform>),
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(string),
            typeof(int),
            typeof(bool),
            typeof(int)
        )]
        public static void OnTBodySkinLoad(TBodySkin __instance)
        {
            // If the loaded skin slot not a shoe, return directly
            if (__instance.SlotId != TBody.SlotID.shoes)
                return;

            if (Plugin.Instance == null)
                return;

            if (__instance.body == null || __instance.obj == null)
                return;

            if (ShoeConfigs.ContainsKey(__instance.body))
            {
                Plugin.Instance.Logger.LogDebug(
                    $"{nameof(OnTBodySkinLoad)}: ShoeConfigs already contains {__instance.obj.name}. How?");

                ShoeConfigs.Remove(__instance.body);
            }

            HighHeelBodyOffset.Clean();

            //// Get the name of the shoe object
            var shoeName = __instance.obj.name;

            // Extract the configuration name from the shoe name
            var configName = Utility.ExtractShoeConfigName(shoeName);
            if (string.IsNullOrEmpty(configName))
            {
#if DEBUG
            Plugin.Instance.Logger.LogWarning($"'{shoeName}' seems not hhmod shoe.");
#endif
                return;
            }


            if (!Plugin.Instance.ShoeDatabase.ContainsKey(configName))
            {
                Plugin.Instance.Logger.LogWarning($"Configuration '{configName}' could not be found!");
                return;
            }

            ShoeConfigs[__instance.body] = configName;

            Plugin.Instance.ImportConfigsAndUpdate(configName);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TBody), "LateUpdate")]
        public static void LateUpdate(TBody __instance)
        {
            // no need to check !__instance.isLoadedBody because original method will check it
            if (Plugin.Instance == null || !Plugin.Instance.Configuration.Enabled.Value)
                return;

            if (!__instance.boMAN)
                ProcessMaid(__instance);
            else
                ProcessMan(__instance);
        }

        private static void ProcessMan(TBody __instance)
        {
            var offset = Plugin.Instance.BodyOffsets.GetManBodyOffsetForScene(currentSceneName, PluginConfig.EnableGlobalPreSceneOffsetSettings.Value);

            if (float.IsNaN(offset) || float.IsInfinity(offset))
            {
                Plugin.Instance.Logger.LogWarning("Offset contains NaN or Infinity in ProcessMan.");
                return;
            }

            var manBody = __instance.GetBone("ManBip");
            if (manBody != null)
            {
                manBody.Translate(Vector3.up * offset, Space.World);
                __instance.SkinMeshUpdate();
            }
        }


        private static void ProcessMaid(TBody __instance)
        {
            if (!__instance.GetSlotVisible(TBody.SlotID.shoes) ||
                (!Plugin.IsDance && !__instance.GetAnimation().isPlaying))
                return;

            if (!MaidTransforms.TryGetValue(__instance, out var transforms))
                return;

            var config = Plugin.Instance.EditMode ? Plugin.Instance.EditModeConfig : GetConfig(__instance);
            if (config == null)
                return;

            ApplyTransformations(__instance, config, transforms);
        }

        /// <summary>
        /// Get the corresponding ShoeConfig configuration from the TBody instance
        /// </summary>
        /// <param name="__instance">TBody instance to get the configuration</param>
        /// <returns>Return the obtained ShoeConfig configuration, or null if not found</returns>
        public static ShoeConfig GetConfig(TBody __instance)
        {
            // Try to get the configuration name from the ShoeConfigs dictionary
            if (ShoeConfigs.TryGetValue(__instance, out var configName) &&
                // Try to get the config from the ShoeDatabase dictionary
                Plugin.Instance.ShoeDatabase.TryGetValue(configName, out var config))
                return config;
            return null;
        }

        private static void ApplyTransformations(TBody __instance, ShoeConfig config, MaidTransforms transforms)
        {
            if (transforms == null || config == null)
            {
                Plugin.Instance.Logger.LogWarning("Transforms or config is null in ApplyTransformations.");
                return;
            }

            if (IsInvalidTransform(transforms.FootL) || IsInvalidTransform(transforms.FootR))
            {
                Plugin.Instance.Logger.LogWarning("One of the foot transforms contains NaN or Infinity in ApplyTransformations.");
                return;
            }

            var offset = Plugin.Instance.BodyOffsets.GetBodyOffsetForScene(currentSceneName, PluginConfig.EnableGlobalPreSceneOffsetSettings.Value, config);

            if (float.IsNaN(offset) || float.IsInfinity(offset))
            {
                Plugin.Instance.Logger.LogWarning("Offset contains NaN or Infinity in ApplyTransformations.");
                return;
            }

            if (offset != 0)
            {
                HighHeelBodyOffset.SetBodyOffset(__instance, offset);
            }

            RotateFoot(transforms.FootL, config.FootLAngle, config.FootLMax);
            RotateFoot(transforms.FootR, config.FootRAngle, config.FootRMax);

            RotateToesIndividual(transforms.ToesL, GetIndividualAngles(config, "L"), true);
            RotateToesIndividual(transforms.ToesR, GetIndividualAngles(config, "R"), false);

            __instance.SkinMeshUpdate();
        }

        public static bool IsInvalidTransform(Transform transform)
        {
            if (transform == null)
                return true;

            var position = transform.localPosition;
            var rotation = transform.localEulerAngles;
            var scale = transform.localScale;

            return float.IsNaN(position.x) || float.IsNaN(position.y) || float.IsNaN(position.z) ||
                   float.IsNaN(rotation.x) || float.IsNaN(rotation.y) || float.IsNaN(rotation.z) ||
                   float.IsNaN(scale.x) || float.IsNaN(scale.y) || float.IsNaN(scale.z) ||
                   float.IsInfinity(position.x) || float.IsInfinity(position.y) || float.IsInfinity(position.z) ||
                   float.IsInfinity(rotation.x) || float.IsInfinity(rotation.y) || float.IsInfinity(rotation.z) ||
                   float.IsInfinity(scale.x) || float.IsInfinity(scale.y) || float.IsInfinity(scale.z);
        }


        private static List<IndividualAngles> GetIndividualAngles(ShoeConfig config, string side)
        {
            if (side == "L")
                return new List<IndividualAngles>
                {
                    new(config.ToeL0AngleX, config.ToeL0AngleY, config.ToeL0AngleZ, "toeL0"),
                    new(config.ToeL01AngleX, config.ToeL01AngleY, config.ToeL01AngleZ, "toeL01"),
                    new(config.ToeL1AngleX, config.ToeL1AngleY, config.ToeL1AngleZ, "toeL1"),
                    new(config.ToeL11AngleX, config.ToeL11AngleY, config.ToeL11AngleZ, "toeL11"),
                    new(config.ToeL2AngleX, config.ToeL2AngleY, config.ToeL2AngleZ, "toeL2"),
                    new(config.ToeL21AngleX, config.ToeL21AngleY, config.ToeL21AngleZ, "toeL21")
                };
            if (side == "R")
                return new List<IndividualAngles>
                {
                    new(config.ToeR0AngleX, config.ToeR0AngleY, config.ToeR0AngleZ, "toeR0"),
                    new(config.ToeR01AngleX, config.ToeR01AngleY, config.ToeR01AngleZ, "toeR01"),
                    new(config.ToeR1AngleX, config.ToeR1AngleY, config.ToeR1AngleZ, "toeR1"),
                    new(config.ToeR11AngleX, config.ToeR11AngleY, config.ToeR11AngleZ, "toeR11"),
                    new(config.ToeR2AngleX, config.ToeR2AngleY, config.ToeR2AngleZ, "toeR2"),
                    new(config.ToeR21AngleX, config.ToeR21AngleY, config.ToeR21AngleZ, "toeR21")
                };

            return new List<IndividualAngles>(); // return an empty list if the side is neither L nor R
        }


        private static void RotateFoot(Transform foot, float angle, float max)
        {
            // 270 degrees represents a foot rotation where the toes point upwards
            const float minimumAngle = 270f;
            var rotation = foot.localRotation.eulerAngles;
            var z = rotation.z;

            if (!Utility.BetweenAngles(z, minimumAngle, max))
                return;

            rotation.z = Utility.ClampAngle(z + angle, minimumAngle, max);

            foot.localRotation = Quaternion.Euler(rotation);
        }

        // Use RotateToesIndividual instead
        private static void RotateToes(IList<Transform> toes, float angle, bool left)
        {
            var inverse = left ? 1f : -1f;

            for (var i = 0; i < 3; i++)
            {
                var offset = 0f;

                if (i != 1)
                    offset = angle switch
                    {
                        > 260f => 0f,
                        < 240f => 15f,
                        _ => 5f
                    };

                toes[i].localRotation = Quaternion.Euler(ToeX[i] * inverse, 0f, angle + offset);
            }
        }

        private static void RotateToesIndividual(IList<Transform> toes, List<IndividualAngles> individualAngles,
            bool left)
        {
            var inverse = left ? 1f : -1f;
            for (var i = 0; i < 6; i++)
            {
                var thisToeAngles = individualAngles[i];
                var rotation = toes[i].localRotation.eulerAngles;
                rotation.x = thisToeAngles.x;
                rotation.y = thisToeAngles.y;
                rotation.z = thisToeAngles.z;
                toes[i].localRotation = Quaternion.Euler(rotation);
            }
        }


        [HarmonyPostfix]
        [HarmonyPatch(typeof(TBody), nameof(TBody.LoadBody_R), typeof(string), typeof(Maid))]
        public static void OnLoadBody_R(TBody __instance)
        {
            if (__instance.boMAN)
                return;
            if (Plugin.Instance == null)
                return;

            MaidTransforms[__instance] = new MaidTransforms(__instance);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(TBodySkin), nameof(TBodySkin.DeleteObj))]
        public static void OnTBodySkinDeleteObj(TBodySkin __instance)
        {
            if (__instance.SlotId != TBody.SlotID.shoes)
                return;
            if (Plugin.Instance == null)
                return;

            if (ShoeConfigs.ContainsKey(__instance.body))
                ShoeConfigs.Remove(__instance.body);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Maid), nameof(Maid.Uninit))]
        public static void OnMaidUninit(Maid __instance)
        {
            if (!__instance.body0.isLoadedBody)
                return;

            OnMaidBodyDestroy(__instance.body0);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TBody), "OnDestroy")]
        public static void OnMaidBodyDestroy(TBody __instance)
        {
            if (MaidTransforms.ContainsKey(__instance))
                MaidTransforms.Remove(__instance);
            if (ShoeConfigs.ContainsKey(__instance))
                ShoeConfigs.Remove(__instance);
        }


        [HarmonyTranspiler]
        [HarmonyPatch(typeof(Maid), "Update")]
        public static IEnumerable<CodeInstruction> MaidUpdateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codeMatcher = new CodeMatcher(instructions);
            codeMatcher.MatchForward(false, new CodeMatch(OpCodes.Sub))
                .Advance(1)
                .InsertAndAdvance(new CodeInstruction(OpCodes.Ldarg_0))
                .InsertAndAdvance(new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(Maid), "body0")))
                .InsertAndAdvance(new CodeInstruction(OpCodes.Call,
                    AccessTools.Method(typeof(HighHeelBodyOffset), nameof(HighHeelBodyOffset.GetBodyOffset))))
                .InsertAndAdvance(new CodeInstruction(OpCodes.Add));
            codeMatcher.MatchForward(false, new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(Maid), "body0")))
                .Advance(1)
                .RemoveInstructionsWithOffsets(0, 1)
                .InsertAndAdvance(new CodeInstruction(OpCodes.Call,
                    AccessTools.Method(typeof(HighHeelBodyOffset), nameof(HighHeelBodyOffset.GetSnityouOutScale))));
            return codeMatcher.InstructionEnumeration();
        }
    }

    public class IndividualAngles
    {
        public IndividualAngles(float xJson, float yJson, float zJson, string boneName)
        {
            switch (boneName)
            {
                case "toeL0":
                    x = xJson + 359.783478f;
                    y = yJson + 0.489697933f;
                    z = zJson + 280.0905f;
                    break;
                case "toeL01":
                    x = xJson + -0.000153921559f;
                    y = yJson + 0.0000699606f;
                    z = zJson + 9.406873f;
                    break;
                case "toeL1":
                    x = xJson + 354.6391f;
                    y = yJson + 2.3375845f;
                    z = zJson + 283.451019f;
                    break;
                case "toeL11":
                    x = xJson + -0.00006798167f;
                    y = yJson + -0.00009544926f;
                    z = zJson + 0.0000599776577f;
                    break;
                case "toeL2":
                    x = xJson + 3.581009f;
                    y = yJson + 358.882568f;
                    z = zJson + 286.8532f;
                    break;
                case "toeL21":
                    x = xJson + 0.0000686013955f;
                    y = yJson + -0.0000236358665f;
                    z = zJson + 3.88611221f;
                    break;

                case "toeR0":
                    x = xJson + 0.216394484f;
                    y = yJson + 359.510223f;
                    z = zJson + 280.0905f;
                    break;
                case "toeR01":
                    x = xJson + 0.0000808577752f;
                    y = yJson + 0.0000769748149f;
                    z = zJson + 9.406906f;
                    break;
                case "toeR1":
                    x = xJson + 5.36096144f;
                    y = yJson + 357.662262f;
                    z = zJson + 283.45108f;
                    break;
                case "toeR11":
                    x = xJson + -0.000161576667f;
                    y = yJson + 0.00000360192917f;
                    z = zJson + -0.0000507995355f;
                    break;
                case "toeR2":
                    x = xJson + 356.4189f;
                    y = yJson + 1.11770535f;
                    z = zJson + 286.8531f;
                    break;
                case "toeR21":
                    x = xJson + 0.00007788669f;
                    y = yJson + 0.0000164253543f;
                    z = zJson + 3.886178f;
                    break;
            }
        }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
}