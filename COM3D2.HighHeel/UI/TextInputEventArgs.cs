using System;
using System.Runtime.CompilerServices;

namespace COM3D2.HighHeel.UI
{
	// Token: 0x0200000B RID: 11
	[NullableContext(1)]
	[Nullable(0)]
	public class TextInputEventArgs : EventArgs
	{
		// Token: 0x0600004A RID: 74 RVA: 0x0000351C File Offset: 0x0000171C
		public TextInputEventArgs(string text)
		{
			this.Text = text;
		}

		// Token: 0x0400002E RID: 46
		public readonly string Text;
	}
}
