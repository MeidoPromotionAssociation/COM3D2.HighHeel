using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using COM3D2.HighHeel.Core;
using UnityEngine;

namespace COM3D2.HighHeel.UI
{
	// Token: 0x02000008 RID: 8
	[NullableContext(1)]
	[Nullable(0)]
	public class MainWindow
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001F RID: 31 RVA: 0x0000253C File Offset: 0x0000073C
		private GUIStyle WindowStyle
		{
			get
			{
				GUIStyle result;
				if ((result = this.windowStyle) == null)
				{
					result = (this.windowStyle = new GUIStyle(GUI.skin.box));
				}
				return result;
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000020 RID: 32 RVA: 0x0000256C File Offset: 0x0000076C
		// (remove) Token: 0x06000021 RID: 33 RVA: 0x000025A4 File Offset: 0x000007A4
		[Nullable(2)]
		[method: NullableContext(2)]
		[Nullable(2)]
		public event EventHandler ReloadEvent;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000022 RID: 34 RVA: 0x000025DC File Offset: 0x000007DC
		// (remove) Token: 0x06000023 RID: 35 RVA: 0x00002614 File Offset: 0x00000814
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
		public event EventHandler<TextInputEventArgs> ImportEvent;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000024 RID: 36 RVA: 0x0000264C File Offset: 0x0000084C
		// (remove) Token: 0x06000025 RID: 37 RVA: 0x00002684 File Offset: 0x00000884
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
		public event EventHandler<TextInputEventArgs> ExportEvent;

		// Token: 0x06000026 RID: 38 RVA: 0x000026BC File Offset: 0x000008BC
		public MainWindow()
		{
			this.editModeConfig = Plugin.Instance.EditModeConfig;
			this.inputs[ShoeConfig.ShoeConfigParameter.BodyOffset] = new NumberInput("Body Offset", this.editModeConfig.BodyOffset);
			this.inputs[ShoeConfig.ShoeConfigParameter.BodyOffset].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.BodyOffset = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.FootLAngle] = new NumberInput("Foot L Angle", this.editModeConfig.FootLAngle);
			this.inputs[ShoeConfig.ShoeConfigParameter.FootLAngle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.FootLAngle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.FootLMax] = new NumberInput("Foot L Max", this.editModeConfig.FootLMax);
			this.inputs[ShoeConfig.ShoeConfigParameter.FootLMax].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.FootLMax = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeLAngle] = new NumberInput("Toe L Angle", this.editModeConfig.ToeLAngle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeLAngle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeLAngle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL0Angle] = new NumberInput("Toe L 0 Angle", this.editModeConfig.ToeL0Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL0Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeL0Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL01Angle] = new NumberInput("Toe L 01 Angle", this.editModeConfig.ToeL01Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL01Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeL01Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL1Angle] = new NumberInput("Toe L 1 Angle", this.editModeConfig.ToeL1Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL1Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeL1Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL11Angle] = new NumberInput("Toe L 11 Angle", this.editModeConfig.ToeL11Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL11Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeL11Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL2Angle] = new NumberInput("Toe L 2 Angle", this.editModeConfig.ToeL2Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL2Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeL2Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL21Angle] = new NumberInput("Toe L 21 Angle", this.editModeConfig.ToeL21Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL21Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeL21Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.FootRAngle] = new NumberInput("Foot R Angle", this.editModeConfig.FootRAngle);
			this.inputs[ShoeConfig.ShoeConfigParameter.FootRAngle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.FootRAngle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.FootRMax] = new NumberInput("Foot R Max", this.editModeConfig.FootRMax);
			this.inputs[ShoeConfig.ShoeConfigParameter.FootRMax].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.FootRMax = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeRAngle] = new NumberInput("Toe R Angle", this.editModeConfig.ToeRAngle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeRAngle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeRAngle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR0Angle] = new NumberInput("Toe R 0 Angle", this.editModeConfig.ToeR0Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR0Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeR0Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR01Angle] = new NumberInput("Toe R 01 Angle", this.editModeConfig.ToeR01Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR01Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeR01Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR1Angle] = new NumberInput("Toe R 1 Angle", this.editModeConfig.ToeR1Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR1Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeR1Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR11Angle] = new NumberInput("Toe R 11 Angle", this.editModeConfig.ToeR11Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR11Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeR11Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR2Angle] = new NumberInput("Toe R 2 Angle", this.editModeConfig.ToeR2Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR2Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeR2Angle = a.Value;
			};
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR21Angle] = new NumberInput("Toe R 21 Angle", this.editModeConfig.ToeR21Angle);
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR21Angle].InputChangeEvent += delegate(object _, [Nullable(1)] NumberInputEventArgs a)
			{
				this.editModeConfig.ToeR21Angle = a.Value;
			};
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002BD0 File Offset: 0x00000DD0
		public void UpdateEditModeValues()
		{
			this.editModeConfig = Plugin.Instance.EditModeConfig;
			this.inputs[ShoeConfig.ShoeConfigParameter.BodyOffset].Value = this.editModeConfig.BodyOffset;
			this.inputs[ShoeConfig.ShoeConfigParameter.FootLAngle].Value = this.editModeConfig.FootLAngle;
			this.inputs[ShoeConfig.ShoeConfigParameter.FootLMax].Value = this.editModeConfig.FootLMax;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeLAngle].Value = this.editModeConfig.ToeLAngle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL0Angle].Value = this.editModeConfig.ToeL0Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL01Angle].Value = this.editModeConfig.ToeL01Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL1Angle].Value = this.editModeConfig.ToeL1Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL11Angle].Value = this.editModeConfig.ToeL11Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL2Angle].Value = this.editModeConfig.ToeL2Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeL21Angle].Value = this.editModeConfig.ToeL21Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.FootRAngle].Value = this.editModeConfig.FootRAngle;
			this.inputs[ShoeConfig.ShoeConfigParameter.FootRMax].Value = this.editModeConfig.FootRMax;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeRAngle].Value = this.editModeConfig.ToeRAngle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR0Angle].Value = this.editModeConfig.ToeR0Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR01Angle].Value = this.editModeConfig.ToeR01Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR1Angle].Value = this.editModeConfig.ToeR1Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR11Angle].Value = this.editModeConfig.ToeR11Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR2Angle].Value = this.editModeConfig.ToeR2Angle;
			this.inputs[ShoeConfig.ShoeConfigParameter.ToeR21Angle].Value = this.editModeConfig.ToeR21Angle;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002E0C File Offset: 0x0000100C
		public void Update()
		{
			if (!this.Visible || Input.mouseScrollDelta.y == 0f)
			{
				return;
			}
			Vector2 vector;
			vector..ctor(Input.mousePosition.x, (float)Screen.height - Input.mousePosition.y);
			if (this.windowRect.Contains(vector))
			{
				Input.ResetInputAxes();
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002E68 File Offset: 0x00001068
		public void Draw()
		{
			if (!this.Visible)
			{
				return;
			}
			this.windowRect.x = Mathf.Clamp(this.windowRect.x, -this.windowRect.width + 20f, (float)(Screen.width - 20));
			this.windowRect.y = Mathf.Clamp(this.windowRect.y, -this.windowRect.height + 20f, (float)(Screen.height - 20));
			bool value = Plugin.Instance.Configuration.Enabled.Value;
			bool editMode = Plugin.Instance.EditMode;
			this.windowRect.height = ((value && editMode) ? 280f : 55f);
			this.windowRect = GUILayout.Window(523961, this.windowRect, new GUI.WindowFunction(this.GuiFunc), string.Empty, this.WindowStyle, new GUILayoutOption[0]);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002F59 File Offset: 0x00001159
		private void GuiFunc(int windowId)
		{
			this.DrawTitlebar();
			this.DrawEditMode();
			GUI.enabled = true;
			GUI.DragWindow();
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002F74 File Offset: 0x00001174
		private void DrawTitlebar()
		{
			Plugin instance = Plugin.Instance;
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			bool value = instance.Configuration.Enabled.Value;
			bool flag = GUILayout.Toggle(value, MainWindow.EnabledLabel, new GUILayoutOption[0]);
			if (flag != value)
			{
				if (value)
				{
					instance.EditMode = false;
				}
				instance.Configuration.Enabled.Value = flag;
			}
			GUI.enabled = flag;
			if (GUILayout.Button(MainWindow.ReloadLabel, new GUILayoutOption[0]))
			{
				EventHandler reloadEvent = this.ReloadEvent;
				if (reloadEvent != null)
				{
					reloadEvent(this, EventArgs.Empty);
				}
			}
			GUILayout.FlexibleSpace();
			GUI.enabled = true;
			if (GUILayout.Button(MainWindow.CloseLabel, new GUILayoutOption[]
			{
				MainWindow.NoExpand
			}))
			{
				this.Visible = false;
			}
			GUILayout.EndHorizontal();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00003034 File Offset: 0x00001234
		private void DrawEditMode()
		{
			Plugin instance = Plugin.Instance;
			GUI.enabled = instance.Configuration.Enabled.Value;
			instance.EditMode = GUILayout.Toggle(instance.EditMode, MainWindow.EditModeLabel, new GUILayoutOption[0]);
			if (!instance.EditMode)
			{
				return;
			}
			this.scrollPos = GUILayout.BeginScrollView(this.scrollPos, new GUILayoutOption[0]);
			foreach (NumberInput numberInput in this.inputs.Values)
			{
				numberInput.Draw();
			}
			GUILayout.EndScrollView();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(MainWindow.ConfigPrefixLabel, new GUILayoutOption[]
			{
				MainWindow.NoExpand
			});
			this.configName = GUILayout.TextField(this.configName, new GUILayoutOption[]
			{
				MainWindow.ConfigNameLayout
			});
			if (GUILayout.Button(MainWindow.ImportLabel, new GUILayoutOption[]
			{
				MainWindow.NoExpand
			}))
			{
				EventHandler<TextInputEventArgs> importEvent = this.ImportEvent;
				if (importEvent != null)
				{
					importEvent(this, new TextInputEventArgs(this.configName));
				}
			}
			if (GUILayout.Button(MainWindow.ExportLabel, new GUILayoutOption[]
			{
				MainWindow.NoExpand
			}))
			{
				EventHandler<TextInputEventArgs> exportEvent = this.ExportEvent;
				if (exportEvent != null)
				{
					exportEvent(this, new TextInputEventArgs(this.configName));
				}
			}
			GUILayout.EndHorizontal();
		}

		// Token: 0x04000014 RID: 20
		private const int WindowId = 523961;

		// Token: 0x04000015 RID: 21
		private static readonly GUILayoutOption NoExpand = GUILayout.ExpandWidth(false);

		// Token: 0x04000016 RID: 22
		private static readonly GUILayoutOption ConfigNameLayout = GUILayout.Width(140f);

		// Token: 0x04000017 RID: 23
		private static readonly GUIContent EnabledLabel = new GUIContent("COM3D2.HighHeel 1.0.0");

		// Token: 0x04000018 RID: 24
		private static readonly GUIContent CloseLabel = new GUIContent("x");

		// Token: 0x04000019 RID: 25
		private static readonly GUIContent ReloadLabel = new GUIContent("Reload");

		// Token: 0x0400001A RID: 26
		private static readonly GUIContent EditModeLabel = new GUIContent("Edit Mode");

		// Token: 0x0400001B RID: 27
		private static readonly GUIContent ConfigPrefixLabel = new GUIContent("hhmod_");

		// Token: 0x0400001C RID: 28
		private static readonly GUIContent ImportLabel = new GUIContent("Import");

		// Token: 0x0400001D RID: 29
		private static readonly GUIContent ExportLabel = new GUIContent("Export");

		// Token: 0x0400001E RID: 30
		private readonly Dictionary<ShoeConfig.ShoeConfigParameter, NumberInput> inputs = new Dictionary<ShoeConfig.ShoeConfigParameter, NumberInput>();

		// Token: 0x0400001F RID: 31
		private ShoeConfig editModeConfig;

		// Token: 0x04000020 RID: 32
		private Vector2 scrollPos = Vector2.zero;

		// Token: 0x04000021 RID: 33
		private Rect windowRect = new Rect(20f, 20f, 260f, 265f);

		// Token: 0x04000022 RID: 34
		public bool Visible;

		// Token: 0x04000023 RID: 35
		private string configName = string.Empty;

		// Token: 0x04000024 RID: 36
		[Nullable(2)]
		private GUIStyle windowStyle;
	}
}
