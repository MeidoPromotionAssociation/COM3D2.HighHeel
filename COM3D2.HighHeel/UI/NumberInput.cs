using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace COM3D2.HighHeel.UI
{
	// Token: 0x02000009 RID: 9
	[NullableContext(1)]
	[Nullable(0)]
	public class NumberInput
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00003399 File Offset: 0x00001599
		// (set) Token: 0x06000042 RID: 66 RVA: 0x000033A1 File Offset: 0x000015A1
		public float Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
				this.textFieldValue = NumberInput.FormatValue(this.value);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000043 RID: 67 RVA: 0x000033BC File Offset: 0x000015BC
		// (remove) Token: 0x06000044 RID: 68 RVA: 0x000033F4 File Offset: 0x000015F4
		[Nullable(new byte[]
		{
			2,
			1
		})]
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public event EventHandler<NumberInputEventArgs> InputChangeEvent;

		// Token: 0x06000045 RID: 69 RVA: 0x00003429 File Offset: 0x00001629
		public NumberInput(string label, float value = 0f)
		{
			this.label = new GUIContent(label);
			this.Value = value;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003450 File Offset: 0x00001650
		public void Draw()
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(this.label, new GUILayoutOption[0]);
			string text = GUILayout.TextField(this.textFieldValue, new GUILayoutOption[]
			{
				NumberInput.TextFieldLayout
			});
			if (text != this.textFieldValue)
			{
				this.textFieldValue = text;
				float num;
				if (float.TryParse(text, out num) && !Mathf.Approximately(this.Value, num))
				{
					this.Value = num;
					EventHandler<NumberInputEventArgs> inputChangeEvent = this.InputChangeEvent;
					if (inputChangeEvent != null)
					{
						inputChangeEvent(this, new NumberInputEventArgs(this.Value));
					}
				}
			}
			GUILayout.EndHorizontal();
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000034E9 File Offset: 0x000016E9
		private static string FormatValue(float value)
		{
			return value.ToString("0.####", CultureInfo.InvariantCulture);
		}

		// Token: 0x04000028 RID: 40
		private static readonly GUILayoutOption TextFieldLayout = GUILayout.Width(70f);

		// Token: 0x04000029 RID: 41
		private readonly GUIContent label;

		// Token: 0x0400002A RID: 42
		private string textFieldValue = string.Empty;

		// Token: 0x0400002B RID: 43
		private float value;
	}
}
