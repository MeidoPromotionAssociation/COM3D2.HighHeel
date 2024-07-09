using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace COM3D2.HighHeel.Core
{
	// Token: 0x0200000E RID: 14
	[NullableContext(1)]
	[Nullable(0)]
	public class MaidTransforms
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00003F2C File Offset: 0x0000212C
		public MaidTransforms(TBody body)
		{
			this.Body = body.GetBone("Bip01");
			this.FootL = body.GetBone("Bip01 L Foot");
			this.FootR = body.GetBone("Bip01 R Foot");
			this.ToeL0 = body.GetBone("Bip01 L Toe0");
			this.ToeL1 = body.GetBone("Bip01 L Toe1");
			this.ToeL2 = body.GetBone("Bip01 L Toe2");
			this.ToeR0 = body.GetBone("Bip01 R Toe0");
			this.ToeR1 = body.GetBone("Bip01 R Toe1");
			this.ToeR2 = body.GetBone("Bip01 R Toe2");
			this.ToesL = new Transform[]
			{
				CMT.SearchObjName(this.FootL, "Bip01 L Toe0", true),
				CMT.SearchObjName(this.ToeL0, "Bip01 L Toe01", true),
				CMT.SearchObjName(this.FootL, "Bip01 L Toe1", true),
				CMT.SearchObjName(this.ToeL1, "Bip01 L Toe11", true),
				CMT.SearchObjName(this.FootL, "Bip01 L Toe2", true),
				CMT.SearchObjName(this.ToeL2, "Bip01 L Toe21", true)
			};
			this.ToesR = new Transform[]
			{
				CMT.SearchObjName(this.FootR, "Bip01 R Toe0", true),
				CMT.SearchObjName(this.ToeR0, "Bip01 R Toe01", true),
				CMT.SearchObjName(this.FootR, "Bip01 R Toe1", true),
				CMT.SearchObjName(this.ToeR1, "Bip01 R Toe11", true),
				CMT.SearchObjName(this.FootR, "Bip01 R Toe2", true),
				CMT.SearchObjName(this.ToeR2, "Bip01 R Toe21", true)
			};
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000040E0 File Offset: 0x000022E0
		public void Deconstruct(out Transform body, out Transform footL, out Transform[] toesL, out Transform toeL0, out Transform toeL1, out Transform toeL2, out Transform footR, out Transform[] toesR, out Transform toeR0, out Transform toeR1, out Transform toeR2)
		{
			body = this.Body;
			footL = this.FootL;
			toesL = this.ToesL;
			toeL0 = this.ToeL0;
			toeL1 = this.ToeL1;
			toeL2 = this.ToeL2;
			footR = this.FootR;
			toesR = this.ToesR;
			toeR0 = this.ToeR0;
			toeR1 = this.ToeR1;
			toeR2 = this.ToeR2;
		}

		// Token: 0x04000035 RID: 53
		public readonly Transform Body;

		// Token: 0x04000036 RID: 54
		public readonly Transform FootL;

		// Token: 0x04000037 RID: 55
		public readonly Transform[] ToesL;

		// Token: 0x04000038 RID: 56
		public readonly Transform ToeL0;

		// Token: 0x04000039 RID: 57
		public readonly Transform ToeL1;

		// Token: 0x0400003A RID: 58
		public readonly Transform ToeL2;

		// Token: 0x0400003B RID: 59
		public readonly Transform FootR;

		// Token: 0x0400003C RID: 60
		public readonly Transform[] ToesR;

		// Token: 0x0400003D RID: 61
		public readonly Transform ToeR0;

		// Token: 0x0400003E RID: 62
		public readonly Transform ToeR1;

		// Token: 0x0400003F RID: 63
		public readonly Transform ToeR2;
	}
}
