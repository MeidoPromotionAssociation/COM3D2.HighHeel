#if COM3D25_UNITY_2022
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace COM3D2.Highheel.Plugin.Core
{
    /// <summary>
    /// COM3D2.5 走官方 _heel：鞋子被标记成高跟鞋后，官方在 IK 阶段用固定的 25° 摆脚，
    /// 并在 Maid.OffsetUpdate 里加一点固定离地。插件只补「配置角度 − 25°」的差值，
    /// 另外接管脚趾造型和按配置/场景的精确离地。
    ///
    /// COM3D2.5 has native _heel support: the game rotates the foot by a fixed 25° during the
    /// IK pass and adds a small fixed ground offset. The plugin only tops up the difference to
    /// the configured angle, and takes over the toe posing and the exact ground clearance.
    /// </summary>
    public static class Hooks25
    {
        /// <summary>官方写死的脚部角度，见 HandFootIKCtrl.HIGHHEEL_ANGLE。</summary>
        private const float OfficialFootAngle = 25f;

        private const float MinimumFootAngle = 270f;

        private sealed class FootState
        {
            /// <summary>有配置，且官方这一帧确实会转脚 —— 两个条件都满足才由插件接手。</summary>
            public bool ShouldApply;

            public bool HasToeSnapshot;
            public float Z;
            public Vector3[] Toes;
        }

        private static readonly Dictionary<HandFootIKCtrl, FootState> FootStates = new();

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TBodySkin), nameof(TBodySkin.Load),
            typeof(MPN), typeof(Transform), typeof(Transform), typeof(Dictionary<string, Transform>),
            typeof(string), typeof(string), typeof(string), typeof(string),
            typeof(int), typeof(string), typeof(int), typeof(bool),
            typeof(int), typeof(bool), typeof(TBodySkin.SplitParam), typeof(TBodySkin.TargetBodyType),
            typeof(int))]
        public static void OnTBodySkinLoad(TBodySkin __instance)
        {
            Hooks.HandleShoeLoaded(__instance);

            if (Plugin.Instance == null || __instance.body == null)
                return;

            // 只有认出了 hhmod_ 配置的鞋子才强制标成高跟鞋，其余保持游戏自己的判断
            // Only shoes we recognised get forced to hiheel, everything else keeps the game's verdict
            if (Hooks.ShoeConfigs.ContainsKey(__instance.body))
                __instance.m_isHiheel = true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(HandFootIKCtrl), "SetHighHeelAngle")]
        public static void BeforeSetHighHeelAngle(HandFootIKCtrl __instance)
        {
            if (Plugin.Instance == null)
                return;

            var body = __instance.myIKMgr != null ? __instance.myIKMgr.body : null;
            if (body == null)
                return;

            if (!FootStates.TryGetValue(__instance, out var state))
            {
                state = new FootState();
                FootStates[__instance] = state;
            }

            var config = Hooks.GetActiveConfig(body);
            state.ShouldApply = config != null;
            state.HasToeSnapshot = false;
            if (!state.ShouldApply)
                return;

            // 官方在 IsHiheel 为假、或 isSetHighAngle 为假（拍照 / 姿势编辑）时会直接返回。
            // 那种场合是游戏故意不转脚，我们也跟着跳过，不去抢骨骼。
            // The official code bails out when IsHiheel is false or isSetHighAngle is false
            // (photo mode, pose editing). That is deliberate, so we skip as well.
            if (!body.IsHiheel || !__instance.isSetHighAngle)
            {
                state.ShouldApply = false;
                return;
            }

            state.Z = __instance.bone.localEulerAngles.z;

            // 官方会把脚趾改成「IK 初始化时抓的快照 − 25°」。ToeControl 为 0 时要还原成动画
            // 当前的姿态，所以先抓一份；抓不到就退化成让官方改。
            // The official code overwrites the toes with (snapshot - 25°). With ToeControl == 0 we
            // put the animation's own pose back, so capture it first.
            if (config.ToeControl == 0f && Hooks.MaidTransforms.TryGetValue(body, out var transforms))
            {
                var toes = __instance.isLeft ? transforms.ToesL : transforms.ToesR;
                state.Toes ??= new Vector3[6];
                for (var i = 0; i < 6; i++)
                    state.Toes[i] = toes[i].localEulerAngles;
                state.HasToeSnapshot = true;
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(HandFootIKCtrl), "SetHighHeelAngle")]
        public static void AfterSetHighHeelAngle(HandFootIKCtrl __instance)
        {
            if (!FootStates.TryGetValue(__instance, out var state) || !state.ShouldApply)
                return;

            var body = __instance.myIKMgr.body;
            var config = Hooks.GetActiveConfig(body);
            if (config == null)
                return;

            var left = __instance.isLeft;
            var foot = __instance.bone;
            var euler = foot.localEulerAngles;

            // 走到这里说明官方这一帧确实转了，applied 就是它加的角度（最多 25°）
            // Reaching this point means the official code did rotate, so applied is its angle
            var applied = Mathf.DeltaAngle(state.Z, euler.z);
            var target = left ? config.FootLAngle : config.FootRAngle;
            var max = left ? config.FootLMax : config.FootRMax;

            // 官方已经转了 25°（乘过姿态系数），只补到配置角度的差额
            // The official 25° (already weighted by foot orientation) is in place, top up the rest
            euler.z = Utility.ClampAngle(state.Z + applied + (target - OfficialFootAngle),
                MinimumFootAngle, max);
            foot.localEulerAngles = euler;

            if (!Hooks.MaidTransforms.TryGetValue(body, out var toeTransforms))
                return;

            if (config.ToeControl != 0f)
            {
                Hooks.RotateToesIndividual(left ? toeTransforms.ToesL : toeTransforms.ToesR,
                    Hooks.GetIndividualAngles(config, left ? "L" : "R"), left);
            }
            else if (state.HasToeSnapshot)
            {
                var toes = left ? toeTransforms.ToesL : toeTransforms.ToesR;
                for (var i = 0; i < 6; i++)
                    toes[i].localEulerAngles = state.Toes[i];
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Maid), "OffsetUpdate")]
        public static void BeforeOffsetUpdate(Maid __instance)
        {
            if (Plugin.Instance == null || __instance.body0 == null)
                return;

            // 有 hhmod 配置时离地由插件按配置算，关掉官方的固定 0.03 补偿，避免两笔叠加
            // With an hhmod config the plugin owns the offset, so switch the official 0.03 off
            // instead of stacking both
            if (Hooks.GetActiveConfig(__instance.body0) != null)
                __instance.isHighHeelOffsetOn = false;
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Maid), "OffsetUpdate")]
        public static void AfterOffsetUpdate(Maid __instance)
        {
            if (Plugin.Instance == null || !Plugin.Instance.Configuration.Enabled.Value)
                return;

            var body = __instance.body0;
            if (body == null)
                return;

            var config = Hooks.GetActiveConfig(body);
            if (config == null)
                return;

            var offset = Plugin.Instance.BodyOffsets.GetBodyOffsetForScene(
                Hooks.currentSceneName, PluginConfig.EnableGlobalPreSceneOffsetSettings.Value, config);

            if (float.IsNaN(offset) || float.IsInfinity(offset))
            {
                Utility.LogWaringWithThrottle("Offset contains NaN or Infinity in COM3D2.5 OffsetUpdate.");
                return;
            }

            if (offset != 0f)
                __instance.AddPosOffset(Vector3.up * offset);
        }
    }
}
#endif
