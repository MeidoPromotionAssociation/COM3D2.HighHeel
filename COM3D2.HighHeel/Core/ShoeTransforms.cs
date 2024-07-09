using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace COM3D2.HighHeel.Core
{
	// Token: 0x02000010 RID: 16
	[NullableContext(2)]
	[Nullable(0)]
	public class ShoeTransforms
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00004724 File Offset: 0x00002924
		[NullableContext(1)]
		public ShoeTransforms(TBodySkin skin)
		{
			this.ShoeL = CMT.SearchObjName(skin.obj_tr, "Bip01 L Foot", false);
			this.ShoeR = CMT.SearchObjName(skin.obj_tr, "Bip01 R Foot", false);
			this.OriginalScale = skin.body.GetBone("Bip01 L Foot").localScale;
		}

		// Token: 0x04000077 RID: 119
		public readonly Transform ShoeL;

		// Token: 0x04000078 RID: 120
		public readonly Transform ShoeR;

		// Token: 0x04000079 RID: 121
		public readonly Vector3 OriginalScale;

		// Token: 0x0400007A RID: 122
		public Vector3 Position = Vector3.zero;

		// Token: 0x0400007B RID: 123
		public Vector3 Rotation = Vector3.zero;

		// Token: 0x0400007C RID: 124
		public Vector3 LocalScale = Vector3.zero;
	}
}
