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
        private static readonly GUILayoutOption ConfigNameLayout = GUILayout.Width(140f);

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
        private Rect windowRect = new(20f, 20f, 260f, 265f);

        private GUIStyle windowStyle;

        public MainWindow()
        {
            editModeConfig = Plugin.Instance!.EditModeConfig;
            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset] = new NumberInput("Body Offset", editModeConfig.BodyOffset);
            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset].InputChangeEvent += (_, a) => editModeConfig.BodyOffset = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset] = new NumberInput("Man Body Offset", editModeConfig.ManBodyOffset);
            inputs[ShoeConfig.ShoeConfigParameter.BodyOffset].InputChangeEvent += (_, a) => editModeConfig.BodyOffset = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.FootLAngle] =
                new NumberInput("Foot L Angle", editModeConfig.FootLAngle);
            inputs[ShoeConfig.ShoeConfigParameter.FootLAngle].InputChangeEvent +=
                (_, a) => editModeConfig.FootLAngle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.FootLMax] = new NumberInput("Foot L Max", editModeConfig.FootLMax);
            inputs[ShoeConfig.ShoeConfigParameter.FootLMax].InputChangeEvent +=
                (_, a) => editModeConfig.FootLMax = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeL0Angle] =
                new NumberInput("Toe L 0 Angle", editModeConfig.ToeL0Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL0Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeL0Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01Angle] =
                new NumberInput("Toe L 01 Angle", editModeConfig.ToeL01Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeL01Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1Angle] =
                new NumberInput("Toe L 1 Angle", editModeConfig.ToeL1Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeL1Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11Angle] =
                new NumberInput("Toe L 11 Angle", editModeConfig.ToeL11Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeL11Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2Angle] =
                new NumberInput("Toe L 2 Angle", editModeConfig.ToeL2Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeL2Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21Angle] =
                new NumberInput("Toe L 21 Angle", editModeConfig.ToeL21Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeL21Angle = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.FootRAngle] =
                new NumberInput("Foot R Angle", editModeConfig.FootRAngle);
            inputs[ShoeConfig.ShoeConfigParameter.FootRAngle].InputChangeEvent +=
                (_, a) => editModeConfig.FootRAngle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.FootRMax] = new NumberInput("Foot R Max", editModeConfig.FootRMax);
            inputs[ShoeConfig.ShoeConfigParameter.FootRMax].InputChangeEvent +=
                (_, a) => editModeConfig.FootRMax = a.Value;

            inputs[ShoeConfig.ShoeConfigParameter.ToeR0Angle] =
                new NumberInput("Toe R 0 Angle", editModeConfig.ToeR0Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR0Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeR0Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01Angle] =
                new NumberInput("Toe R 01 Angle", editModeConfig.ToeR01Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeR01Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1Angle] =
                new NumberInput("Toe R 1 Angle", editModeConfig.ToeR1Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeR1Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11Angle] =
                new NumberInput("Toe R 11 Angle", editModeConfig.ToeR11Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeR11Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2Angle] =
                new NumberInput("Toe R 2 Angle", editModeConfig.ToeR2Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeR2Angle = a.Value;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21Angle] =
                new NumberInput("Toe R 21 Angle", editModeConfig.ToeR21Angle);
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21Angle].InputChangeEvent +=
                (_, a) => editModeConfig.ToeR21Angle = a.Value;
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

            inputs[ShoeConfig.ShoeConfigParameter.ToeL0Angle].Value = editModeConfig.ToeL0Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL01Angle].Value = editModeConfig.ToeL01Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL1Angle].Value = editModeConfig.ToeL1Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL11Angle].Value = editModeConfig.ToeL11Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL2Angle].Value = editModeConfig.ToeL2Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeL21Angle].Value = editModeConfig.ToeL21Angle;

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

            inputs[ShoeConfig.ShoeConfigParameter.ToeR0Angle].Value = editModeConfig.ToeR0Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR01Angle].Value = editModeConfig.ToeR01Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR1Angle].Value = editModeConfig.ToeR1Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR11Angle].Value = editModeConfig.ToeR11Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR2Angle].Value = editModeConfig.ToeR2Angle;
            inputs[ShoeConfig.ShoeConfigParameter.ToeR21Angle].Value = editModeConfig.ToeR21Angle;

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
            windowRect.height = pluginEnabled && editModeEnabled ? 280f : 55f;

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