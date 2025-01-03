using System;
using System.Collections.Generic;
using COM3D2.Highheel.Plugin.Core;
using UnityEngine;

namespace COM3D2.Highheel.Plugin.UI
{
    public class MainWindow
    {
        private const int WindowId = 523961;

        private static readonly GUILayoutOption NoExpand = GUILayout.ExpandWidth(false);
        private static readonly GUILayoutOption ConfigNameLayout = GUILayout.Width(160f);

        private static readonly GUIContent EnabledLabel = new(Plugin.PluginString);
        private static readonly GUIContent CloseLabel = new("x");
        private static readonly GUIContent ReloadLabel = new("Reload");
        private static readonly GUIContent EditModeLabel = new("Edit Mode");
        private static readonly GUIContent ConfigPrefixLabel = new("hhmod_");
        private static readonly GUIContent ImportLabel = new("Import");
        private static readonly GUIContent ExportLabel = new("Export");

        private readonly Dictionary<ShoeConfig.ShoeConfigParameter, NumberInput> inputs = new();

        private string configName = string.Empty;
        private ShoeConfig editModeConfig;

        private Vector2 scrollPos = Vector2.zero;
        public bool Visible;
        private Rect windowRect = new(20f, 20f, 260f, 530f);

        private GUIStyle windowStyle;

        public MainWindow()
        {
            editModeConfig = Plugin.Instance!.EditModeConfig;

            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset] = new NumberInput("Body Offset", editModeConfig.BodyOffset);
            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset].InputChangeEvent += (_, a) => editModeConfig.BodyOffset = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ManBodyOffset] = new NumberInput("Man Body Offset", editModeConfig.ManBodyOffset);
            inputs[ShoeConfig.ShoeConfigParameter.ManBodyOffset].InputChangeEvent += (_, a) => editModeConfig.ManBodyOffset = a.Value;



            inputs[ShoeConfig.ShoeConfigParameter.FootLAngle] = new NumberInput("Foot L Angle", editModeConfig.FootLAngle);
            inputs[ShoeConfig.ShoeConfigParameter.FootLAngle].InputChangeEvent += (_, a) => editModeConfig.FootLAngle = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.FootLMax] = new NumberInput("Foot L Max", editModeConfig.FootLMax);
            inputs[ShoeConfig.ShoeConfigParameter.FootLMax].InputChangeEvent += (_, a) => editModeConfig.FootLMax = a.Value;


            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleX] = new NumberInput("Toe L 0 Angle X (Pinky)", editModeConfig.ToeL0AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeL0AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleY] = new NumberInput("Toe L 0 Angle Y (Pinky)", editModeConfig.ToeL0AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeL0AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleZ] = new NumberInput("Toe L 0 Angle Z (Pinky)", editModeConfig.ToeL0AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeL0AngleZ = a.Value;


            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleX] = new NumberInput("Toe L 01 Angle X", editModeConfig.ToeL01AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeL01AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleY] = new NumberInput("Toe L 01 Angle Y", editModeConfig.ToeL01AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeL01AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleZ] = new NumberInput("Toe L 01 Angle Z", editModeConfig.ToeL01AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeL01AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleX] = new NumberInput("Toe L 1 Angle X", editModeConfig.ToeL1AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeL1AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleY] = new NumberInput("Toe L 1 Angle Y", editModeConfig.ToeL1AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeL1AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleZ] = new NumberInput("Toe L 1 Angle Z", editModeConfig.ToeL1AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeL1AngleZ = a.Value;


            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleX] = new NumberInput("Toe L 11 Angle X", editModeConfig.ToeL11AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeL11AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleY] = new NumberInput("Toe L 11 Angle Y", editModeConfig.ToeL11AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeL11AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleZ] = new NumberInput("Toe L 11 Angle Z", editModeConfig.ToeL11AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeL11AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleX] = new NumberInput("Toe L 2 Angle X (Big)", editModeConfig.ToeL2AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeL2AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleY] = new NumberInput("Toe L 2 Angle Y (Big)", editModeConfig.ToeL2AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeL2AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleZ] = new NumberInput("Toe L 2 Angle Z (Big)", editModeConfig.ToeL2AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeL2AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleX] = new NumberInput("Toe L 21 Angle X", editModeConfig.ToeL21AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeL21AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleY] = new NumberInput("Toe L 21 Angle Y", editModeConfig.ToeL21AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeL21AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleZ] = new NumberInput("Toe L 21 Angle Z", editModeConfig.ToeL21AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeL21AngleZ = a.Value;




            inputs[ShoeConfig.ShoeConfigParameter.FootRAngle] = new NumberInput("Foot R Angle", editModeConfig.FootRAngle);
            inputs[ShoeConfig.ShoeConfigParameter.FootRAngle].InputChangeEvent += (_, a) => editModeConfig.FootRAngle = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.FootRMax] = new NumberInput("Foot R Max", editModeConfig.FootRMax);
            inputs[ShoeConfig.ShoeConfigParameter.FootRMax].InputChangeEvent += (_, a) => editModeConfig.FootRMax = a.Value;


            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleX] = new NumberInput("Toe R 0 Angle X (Pinky)", editModeConfig.ToeR0AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeR0AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleY] = new NumberInput("Toe R 0 Angle Y (Pinky)", editModeConfig.ToeR0AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeR0AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleZ] = new NumberInput("Toe R 0 Angle Z (Pinky)", editModeConfig.ToeR0AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeR0AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleX] = new NumberInput("Toe R 01 Angle X", editModeConfig.ToeR01AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeR01AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleY] = new NumberInput("Toe R 01 Angle Y", editModeConfig.ToeR01AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeR01AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleZ] = new NumberInput("Toe R 01 Angle Z", editModeConfig.ToeR01AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeR01AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleX] = new NumberInput("Toe R 1 Angle X", editModeConfig.ToeR1AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeR1AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleY] = new NumberInput("Toe R 1 Angle Y", editModeConfig.ToeR1AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeR1AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleZ] = new NumberInput("Toe R 1 Angle Z", editModeConfig.ToeR1AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeR1AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleX] = new NumberInput("Toe R 11 Angle X", editModeConfig.ToeR11AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeR11AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleY] = new NumberInput("Toe R 11 Angle Y", editModeConfig.ToeR11AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeR11AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleZ] = new NumberInput("Toe R 11 Angle Z", editModeConfig.ToeR11AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeR11AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleX] = new NumberInput("Toe R 2 Angle X (Big)", editModeConfig.ToeR2AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeR2AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleY] = new NumberInput("Toe R 2 Angle Y (Big)", editModeConfig.ToeR2AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeR2AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleZ] = new NumberInput("Toe R 2 Angle Z (Big)", editModeConfig.ToeR2AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeR2AngleZ = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleX] = new NumberInput("Toe R 21 Angle X", editModeConfig.ToeR21AngleX);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleX].InputChangeEvent += (_, a) => editModeConfig.ToeR21AngleX = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleY] = new NumberInput("Toe R 21 Angle Y", editModeConfig.ToeR21AngleY);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleY].InputChangeEvent += (_, a) => editModeConfig.ToeR21AngleY = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleZ] = new NumberInput("Toe R 21 Angle Z", editModeConfig.ToeR21AngleZ);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleZ].InputChangeEvent += (_, a) => editModeConfig.ToeR21AngleZ = a.Value;

        }

        private GUIStyle WindowStyle => windowStyle ??= new GUIStyle(GUI.skin.box);

        public event EventHandler ReloadEvent;
        public event EventHandler<TextInputEventArgs> ImportEvent;
        public event EventHandler<TextInputEventArgs> ExportEvent;

        public void UpdateEditModeValues()
        {
            editModeConfig = Plugin.Instance!.EditModeConfig;
            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset].Value = editModeConfig.BodyOffset;
            inputs[ShoeConfig.ShoeConfigParameter.ManBodyOffset].Value = editModeConfig.ManBodyOffset;

            inputs[ShoeConfig.ShoeConfigParameter.FootLAngle].Value = editModeConfig.FootLAngle;
            inputs[ShoeConfig.ShoeConfigParameter.FootLMax].Value = editModeConfig.FootLMax;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleX].Value = editModeConfig.ToeL0AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleY].Value = editModeConfig.ToeL0AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0AngleZ].Value = editModeConfig.ToeL0AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleX].Value = editModeConfig.ToeL01AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleY].Value = editModeConfig.ToeL01AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01AngleZ].Value = editModeConfig.ToeL01AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleX].Value = editModeConfig.ToeL1AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleY].Value = editModeConfig.ToeL1AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1AngleZ].Value = editModeConfig.ToeL1AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleX].Value = editModeConfig.ToeL11AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleY].Value = editModeConfig.ToeL11AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11AngleZ].Value = editModeConfig.ToeL11AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleX].Value = editModeConfig.ToeL2AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleY].Value = editModeConfig.ToeL2AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2AngleZ].Value = editModeConfig.ToeL2AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleX].Value = editModeConfig.ToeL21AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleY].Value = editModeConfig.ToeL21AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21AngleZ].Value = editModeConfig.ToeL21AngleZ;



            inputs[ShoeConfig.ShoeConfigParameter.FootRAngle].Value = editModeConfig.FootRAngle;
            inputs[ShoeConfig.ShoeConfigParameter.FootRMax].Value = editModeConfig.FootRMax;


            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleX].Value = editModeConfig.ToeR0AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleY].Value = editModeConfig.ToeR0AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0AngleZ].Value = editModeConfig.ToeR0AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleX].Value = editModeConfig.ToeR01AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleY].Value = editModeConfig.ToeR01AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01AngleZ].Value = editModeConfig.ToeR01AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleX].Value = editModeConfig.ToeR1AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleY].Value = editModeConfig.ToeR1AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1AngleZ].Value = editModeConfig.ToeR1AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleX].Value = editModeConfig.ToeR11AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleY].Value = editModeConfig.ToeR11AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11AngleZ].Value = editModeConfig.ToeR11AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleX].Value = editModeConfig.ToeR2AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleY].Value = editModeConfig.ToeR2AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2AngleZ].Value = editModeConfig.ToeR2AngleZ;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleX].Value = editModeConfig.ToeR21AngleX;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleY].Value = editModeConfig.ToeR21AngleY;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21AngleZ].Value = editModeConfig.ToeR21AngleZ;
        }

        public void Update()
        {
            if (!Visible || Input.mouseScrollDelta.y == 0f) return;

            var mousePos = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            if (windowRect.Contains(mousePos)) Input.ResetInputAxes();
        }

        public void Draw()
        {
            if (!Visible) return;

            windowRect.x = Mathf.Clamp(windowRect.x, -windowRect.width + 20, Screen.width - 20);
            windowRect.y = Mathf.Clamp(windowRect.y, -windowRect.height + 20, Screen.height - 20);

            var pluginEnabled = Plugin.Instance!.Configuration.Enabled.Value;
            var editModeEnabled = Plugin.Instance!.EditMode;
            windowRect.height = pluginEnabled && editModeEnabled ? 560f : 55f;

            windowRect = GUILayout.Window(WindowId, windowRect, GuiFunc, string.Empty, WindowStyle);
        }

        private void GuiFunc(int windowId)
        {
            DrawTitlebar();
            DrawEditMode();

            GUI.enabled = true;
            GUI.DragWindow();
        }

        private void DrawTitlebar()
        {
            var plugin = Plugin.Instance!;

            GUILayout.BeginHorizontal();

            var configPluginEnabled = plugin.Configuration.Enabled.Value;

            var pluginEnabled = GUILayout.Toggle(configPluginEnabled, EnabledLabel);

            if (pluginEnabled != configPluginEnabled)
            {
                if (configPluginEnabled) plugin.EditMode = false;
                plugin.Configuration.Enabled.Value = pluginEnabled;
            }

            GUI.enabled = pluginEnabled;

            if (GUILayout.Button(ReloadLabel)) ReloadEvent?.Invoke(this, EventArgs.Empty);

            GUILayout.FlexibleSpace();

            GUI.enabled = true;

            if (GUILayout.Button(CloseLabel, NoExpand)) Visible = false;

            GUILayout.EndHorizontal();
        }

        private void DrawEditMode()
        {
            var plugin = Plugin.Instance!;

            GUI.enabled = plugin.Configuration.Enabled.Value;

            plugin.EditMode = GUILayout.Toggle(plugin.EditMode, EditModeLabel);

            if (!plugin.EditMode) return;

            scrollPos = GUILayout.BeginScrollView(scrollPos);

            foreach (var input in inputs.Values) input.Draw();

            GUILayout.EndScrollView();

            GUILayout.FlexibleSpace();

            GUILayout.BeginHorizontal();

            GUILayout.Label(ConfigPrefixLabel, NoExpand);

            configName = GUILayout.TextField(configName, ConfigNameLayout);

            if (GUILayout.Button(ImportLabel, NoExpand)) ImportEvent?.Invoke(this, new TextInputEventArgs(configName));

            if (GUILayout.Button(ExportLabel, NoExpand)) ExportEvent?.Invoke(this, new TextInputEventArgs(configName));

            GUILayout.EndHorizontal();
        }
    }
}