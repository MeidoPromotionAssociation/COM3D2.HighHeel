using System;

namespace COM3D2.HighHeel.UI
{
	// Token: 0x0200000A RID: 10
	public class NumberInputEventArgs : EventArgs
	{
		// Token: 0x06000049 RID: 73 RVA: 0x0000350D File Offset: 0x0000170D
		public NumberInputEventArgs(float value)
		{
			this.Value = value;
		}

		// Token: 0x0400002D RID: 45
		public readonly float Value;
	}
}
