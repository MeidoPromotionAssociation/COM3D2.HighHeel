using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.HighHeel.Core
{
	// Token: 0x0200000C RID: 12
	[NullableContext(1)]
	[Nullable(0)]
	public static class Hooks
	{
		// Token: 0x0600004B RID: 75 RVA: 0x0000352C File Offset: 0x0000172C
		[HarmonyPostfix]
		[HarmonyPatch(typeof(TBodySkin), "Load", new Type[]
		{
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
		})]
		public static void OnTBodySkinLoad(TBodySkin __instance)
		{
			if (__instance.SlotId != 14)
			{
				return;
			}
			if (Plugin.Instance == null)
			{
				return;
			}
			if (Hooks.ShoeConfigs.ContainsKey(__instance.body))
			{
				Plugin.Instance.Logger.LogDebug("OnTBodySkinLoad: ShoeConfigs already contains " + __instance.obj.name + ". How?");
				Hooks.ShoeConfigs.Remove(__instance.body);
			}
			string name = __instance.obj.name;
			int startIndex;
			if ((startIndex = name.IndexOf("hhmod_", StringComparison.Ordinal)) < 0)
			{
				return;
			}
			string text = name.Substring(startIndex, 9);
			if (!Plugin.Instance.ShoeDatabase.ContainsKey(text))
			{
				Plugin.Instance.Logger.LogWarning("Configuration '" + text + "' could not be found!");
				return;
			}
			Hooks.ShoeConfigs[__instance.body] = text;
			Plugin.Instance.ImportConfigsAndUpdate(text);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003614 File Offset: 0x00001814
		[HarmonyPostfix]
		[HarmonyPatch(typeof(TBody), "LateUpdate")]
		public static void LateUpdate(TBody __instance)
		{
			if (__instance.boMAN || !__instance.isLoadedBody)
			{
				return;
			}
			if (Plugin.Instance == null || !Plugin.Instance.Configuration.Enabled.Value)
			{
				return;
			}
			if (!__instance.GetSlotVisible(14))
			{
				return;
			}
			if (!Plugin.IsDance && !__instance.GetAnimation().isPlaying)
			{
				return;
			}
			MaidTransforms maidTransforms;
			if (!Hooks.MaidTransforms.TryGetValue(__instance, out maidTransforms))
			{
				return;
			}
			ShoeConfig editModeConfig;
			if (Plugin.Instance.EditMode)
			{
				editModeConfig = Plugin.Instance.EditModeConfig;
			}
			else
			{
				string key;
				if (!Hooks.ShoeConfigs.TryGetValue(__instance, out key))
				{
					return;
				}
				if (!Plugin.Instance.ShoeDatabase.TryGetValue(key, out editModeConfig))
				{
					return;
				}
			}
			Transform transform;
			Transform transform2;
			Transform[] array;
			Transform transform3;
			Transform transform4;
			Transform transform5;
			Transform transform6;
			Transform[] array2;
			Transform transform7;
			Transform transform8;
			Transform transform9;
			maidTransforms.Deconstruct(out transform, out transform2, out array, out transform3, out transform4, out transform5, out transform6, out array2, out transform7, out transform8, out transform9);
			Transform transform10 = transform;
			Transform foot = transform2;
			Transform[] toes = array;
			Transform foot2 = transform6;
			Transform[] toes2 = array2;
			float num;
			float num2;
			float num3;
			float num4;
			float num5;
			float num6;
			float num7;
			float num8;
			float num9;
			float num10;
			float num11;
			float num12;
			float num13;
			float num14;
			float num15;
			float num16;
			float num17;
			float num18;
			float num19;
			float num20;
			float num21;
			float num22;
			float num23;
			float num24;
			float num25;
			float num26;
			float num27;
			float num28;
			float num29;
			float num30;
			float num31;
			float num32;
			float num33;
			float num34;
			float num35;
			float num36;
			float num37;
			float num38;
			float num39;
			float num40;
			float num41;
			float num42;
			float num43;
			float num44;
			float num45;
			float num46;
			float num47;
			float num48;
			float num49;
			float num50;
			float num51;
			float num52;
			float num53;
			float num54;
			float num55;
			editModeConfig.Deconstruct(out num, out num2, out num3, out num4, out num5, out num6, out num7, out num8, out num9, out num10, out num11, out num12, out num13, out num14, out num15, out num16, out num17, out num18, out num19, out num20, out num21, out num22, out num23, out num24, out num25, out num26, out num27, out num28, out num29, out num30, out num31, out num32, out num33, out num34, out num35, out num36, out num37, out num38, out num39, out num40, out num41, out num42, out num43, out num44, out num45, out num46, out num47, out num48, out num49, out num50, out num51, out num52, out num53, out num54, out num55);
			//float num56 = num;
			float angle = num2;
			float max = num3;
			float correctionAngle = num4;
			float xJson = num11;
			float xJson2 = num12;
			float xJson3 = num13;
			float xJson4 = num14;
			float xJson5 = num15;
			float xJson6 = num16;
			float yJson = num17;
			float yJson2 = num18;
			float yJson3 = num19;
			float yJson4 = num20;
			float yJson5 = num21;
			float yJson6 = num22;
			float zJson = num23;
			float zJson2 = num24;
			float zJson3 = num25;
			float zJson4 = num26;
			float zJson5 = num27;
			float zJson6 = num28;
			float angle2 = num29;
			float max2 = num30;
			float correctionAngle2 = num31;
			float xJson7 = num38;
			float xJson8 = num39;
			float xJson9 = num40;
			float xJson10 = num41;
			float xJson11 = num42;
			float xJson12 = num43;
			float yJson7 = num44;
			float yJson8 = num45;
			float yJson9 = num46;
			float yJson10 = num47;
			float yJson11 = num48;
			float yJson12 = num49;
			float zJson7 = num50;
			float zJson8 = num51;
			float zJson9 = num52;
			float zJson10 = num53;
			float zJson11 = num54;
			float zJson12 = num55;

			//overwrite offset
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            float num56 = Plugin.Instance.BodyOffsets.GetBodyOffsetForScene(currentSceneIndex);
            Debug.Log($"HighHeel currentSceneIndex: {currentSceneIndex} offset :{num56}");

			transform10.Translate(Vector3.up * num56, 0);
			Hooks.<LateUpdate>g__RotateFoot|4_0(foot, angle, max);
			Hooks.<LateUpdate>g__RotateFoot|4_0(foot2, angle2, max2);
			Hooks.<LateUpdate>g__RotateToesIndividual|4_2(toes, correctionAngle, new List<IndividualAngles>
			{
				new IndividualAngles(xJson, yJson, zJson, "toeL0"),
				new IndividualAngles(xJson2, yJson2, zJson2, "toeL01"),
				new IndividualAngles(xJson3, yJson3, zJson3, "toeL1"),
				new IndividualAngles(xJson4, yJson4, zJson4, "toeL11"),
				new IndividualAngles(xJson5, yJson5, zJson5, "toeL2"),
				new IndividualAngles(xJson6, yJson6, zJson6, "toeL21")
			}, true);
			Hooks.<LateUpdate>g__RotateToesIndividual|4_2(toes2, correctionAngle2, new List<IndividualAngles>
			{
				new IndividualAngles(xJson7, yJson7, zJson7, "toeR0"),
				new IndividualAngles(xJson8, yJson8, zJson8, "toeR01"),
				new IndividualAngles(xJson9, yJson9, zJson9, "toeR1"),
				new IndividualAngles(xJson10, yJson10, zJson10, "toeR11"),
				new IndividualAngles(xJson11, yJson11, zJson11, "toeR2"),
				new IndividualAngles(xJson12, yJson12, zJson12, "toeL21")
			}, false);
			__instance.SkinMeshUpdate();
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003977 File Offset: 0x00001B77
		[HarmonyPostfix]
		[HarmonyPatch(typeof(TBody), "LoadBody_R")]
		public static void OnLoadBody_R(TBody __instance)
		{
			if (__instance.boMAN)
			{
				return;
			}
			if (Plugin.Instance == null)
			{
				return;
			}
			Hooks.MaidTransforms[__instance] = new MaidTransforms(__instance);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000039A1 File Offset: 0x00001BA1
		[HarmonyPrefix]
		[HarmonyPatch(typeof(TBodySkin), "DeleteObj")]
		public static void OnTBodySkinDeleteObj(TBodySkin __instance)
		{
			if (__instance.SlotId != 14)
			{
				return;
			}
			if (Plugin.Instance == null)
			{
				return;
			}
			if (Hooks.ShoeConfigs.ContainsKey(__instance.body))
			{
				Hooks.ShoeConfigs.Remove(__instance.body);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000039DF File Offset: 0x00001BDF
		[HarmonyPrefix]
		[HarmonyPatch(typeof(Maid), "Uninit")]
		public static void OnMaidUninit(Maid __instance)
		{
			if (!__instance.body0.isLoadedBody)
			{
				return;
			}
			Hooks.OnMaidBodyDestroy(__instance.body0);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000039FA File Offset: 0x00001BFA
		[HarmonyPostfix]
		[HarmonyPatch(typeof(TBody), "OnDestroy")]
		public static void OnMaidBodyDestroy(TBody __instance)
		{
			if (Hooks.MaidTransforms.ContainsKey(__instance))
			{
				Hooks.MaidTransforms.Remove(__instance);
			}
			if (Hooks.ShoeConfigs.ContainsKey(__instance))
			{
				Hooks.ShoeConfigs.Remove(__instance);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003A50 File Offset: 0x00001C50
		[CompilerGenerated]
		internal static void <LateUpdate>g__RotateFoot|4_0(Transform foot, float angle, float max)
		{
			Vector3 eulerAngles = foot.localRotation.eulerAngles;
			float z = eulerAngles.z;
			if (!Utility.BetweenAngles(z, 270f, max))
			{
				return;
			}
			eulerAngles.z = Utility.ClampAngle(z + angle, 270f, max);
			foot.localRotation = Quaternion.Euler(eulerAngles);
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003AA4 File Offset: 0x00001CA4
		[CompilerGenerated]
		internal static void <LateUpdate>g__RotateToes|4_1(IList<Transform> toes, float angle, bool left)
		{
			float num = left ? 1f : -1f;
			for (int i = 0; i < 3; i++)
			{
				float num2 = 0f;
				if (i != 1)
				{
					float num3;
					if (angle <= 260f)
					{
						if (angle >= 240f)
						{
							num3 = 5f;
						}
						else
						{
							num3 = 15f;
						}
					}
					else
					{
						num3 = 0f;
					}
					num2 = num3;
				}
				toes[i].localRotation = Quaternion.Euler(Hooks.ToeX[i] * num, 0f, angle + num2);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00003B24 File Offset: 0x00001D24
		[CompilerGenerated]
		internal static void <LateUpdate>g__RotateToesIndividual|4_2(IList<Transform> toes, float correctionAngle, List<IndividualAngles> individualAngles, bool left)
		{
			for (int i = 0; i < 6; i++)
			{
				IndividualAngles individualAngles2 = individualAngles[i];
				Vector3 eulerAngles = toes[i].localRotation.eulerAngles;
				eulerAngles.x = individualAngles2.x;
				eulerAngles.y = individualAngles2.y;
				eulerAngles.z = individualAngles2.z;
				toes[i].localRotation = Quaternion.Euler(eulerAngles);
			}
		}

		// Token: 0x0400002F RID: 47
		private static readonly float[] ToeX = new float[6];

		// Token: 0x04000030 RID: 48
		private static readonly Dictionary<TBody, MaidTransforms> MaidTransforms = new Dictionary<TBody, MaidTransforms>();

		// Token: 0x04000031 RID: 49
		private static readonly Dictionary<TBody, string> ShoeConfigs = new Dictionary<TBody, string>();
	}
}
