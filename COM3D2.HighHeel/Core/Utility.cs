using System;
using UnityEngine;

namespace COM3D2.HighHeel.Core
{
	// Token: 0x02000011 RID: 17
	public static class Utility
	{
		// Token: 0x060000CF RID: 207 RVA: 0x000047A4 File Offset: 0x000029A4
		public static float ClampAngle(float angle, float min, float max)
		{
			float num = Utility.Normalize180(min - angle);
			float num2 = Utility.Normalize180(max - angle);
			if (num <= 0f && num2 >= 0f)
			{
				return angle;
			}
			if (Mathf.Abs(num) >= Mathf.Abs(num2))
			{
				return max;
			}
			return min;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000047E6 File Offset: 0x000029E6
		public static bool BetweenAngles(float angle, float min, float max)
		{
			return Utility.Normalize180(min - angle) <= 0f && Utility.Normalize180(max - angle) >= 0f;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000480B File Offset: 0x00002A0B
		public static float Normalize180(float angle)
		{
			angle %= 360f;
			angle = (angle + 360f) % 360f;
			if (angle > 180f)
			{
				angle -= 360f;
			}
			return angle;
		}
	}
}
