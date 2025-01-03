using BepInEx.Configuration;
using UnityEngine;

namespace COM3D2.Highheel.Plugin
{
    public class PluginConfig
    {
        public ConfigEntry<bool> Enabled { get; private set; }
        public ConfigEntry<KeyboardShortcut> UIShortcut { get; private set; }
        public static ConfigEntry<bool> EnableGlobalPreSceneOffsetSettings { get; private set; }
        public static ConfigEntry<bool> UseManOffset { get; private set; }

        public PluginConfig(ConfigFile config)
        {
            const string configSection = "Config";

            Enabled = config.Bind(configSection, nameof(Enabled), true, "Plugin enabled");

            UIShortcut = config.Bind(configSection, nameof(UIShortcut), new KeyboardShortcut(KeyCode.F9, KeyCode.LeftControl), "Shortcut to toggle configuration UI");

            EnableGlobalPreSceneOffsetSettings = config.Bind(configSection,nameof(EnableGlobalPreSceneOffsetSettings) , true, "If ture, enable global pre-scene offset settings, else use pre-shoes pre-scene offset settings");

            UseManOffset = config.Bind(configSection, nameof(UseManOffset), true, "If ture, use man offset, else don't offset man. This is to align man with maid in yotogi");
        }
    }
}