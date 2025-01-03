using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using COM3D2.Highheel.Plugin.Core;
using COM3D2.Highheel.Plugin.UI;
using HarmonyLib;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

[assembly: AssemblyVersion("1.0.9.0")]
namespace COM3D2.Highheel.Plugin
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "com.ongame.com3d2.highheel";
        public const string PluginName = "COM3D2.HighHeel";
        public const string PluginVersion = "1.0.9.0";
        public const string PluginString = PluginName + " " + PluginVersion;

        private const string ConfigName = "Configuration.cfg";

        private static readonly string ConfigPath = Path.Combine(Paths.ConfigPath, PluginName);
        private static readonly string ShoeConfigPath = Path.Combine(ConfigPath, "Configurations");
        private static readonly string BodyOffsetConfigPath = Path.Combine(ConfigPath, "GlobalBodyOffset.json");

        public readonly PluginConfig Configuration;
        public new readonly ManualLogSource Logger;
        private readonly MainWindow mainWindow;
        public ShoeConfig EditModeConfig = new();

        public Plugin()
        {
            Instance = this;
            try
            {
                Harmony.CreateAndPatchAll(typeof(Hooks));
            }
            catch (Exception e)
            {
                base.Logger.LogError($"Unable to inject core because: {e.Message}");
                base.Logger.LogError(e.StackTrace);
                DestroyImmediate(this);
                return;
            }

            Configuration =
                new PluginConfig(new ConfigFile(Path.Combine(ConfigPath, ConfigName), false, Info.Metadata));
            Logger = base.Logger;

            LoadBodyOffsetConfig();

            mainWindow = new MainWindow();

            mainWindow.ReloadEvent += (_, _) =>
            {
                ShoeDatabase = LoadShoeDatabase();
                LoadBodyOffsetConfig();
            };

            mainWindow.ExportEvent += (_, args) => ExportConfiguration(EditModeConfig, args.Text);

            mainWindow.ImportEvent += (_, args) =>
            {
                ImportConfigsAndUpdate(args.Text);
            };

            SceneManager.sceneLoaded += (_, _) => IsDance = FindObjectOfType<DanceMain>() != null;

            ShoeDatabase = LoadShoeDatabase();

            ImportConfigsAndUpdate("");
        }

        public static bool IsDance { get; private set; }

        public Dictionary<string, ShoeConfig> ShoeDatabase { get; private set; }

        public bool EditMode { get; set; }

        public static Plugin Instance { get; private set; }

        public BodyOffsetConfig BodyOffsets { get; private set; }

        private void Update()
        {
            if (Configuration.UIShortcut.Value.IsUp())
            {
                ToggleGUI();
            }

            mainWindow.Update();
        }

        private void OnGUI()
        {
            mainWindow.Draw();
        }

        void Start()
        {
            if (PluginConfig.AddGearMenuButton.Value)
            {
                // add button to GearMenu
                GearMenu.Buttons.Add(
                    "HighHeel",
                    "Toggle COM3D2.HighHeel.Plugin GUI",
                    Convert.FromBase64String(
                        "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAAXNSR0IB2cksfwAAAAlwSFlzAAAWJQAAFiUBSVIk8AAAANtQTFRF////+fn57u7u3d3dzc3NxsbGxcXFzMzMpqamo6Ojn5+f2dnZqKioxMTEtbW1vLy8ubm5ycnJgYGBlpaWtLS0SkpKp6enT09PiIiIs7OzmJiYgICAy8vLtra2VlZWcnJym5ubDg4OUFBQ0dHRdHR0VVVVt7e3FRUVPz8/HBwcX19fra2tf39/7+/vmpqaHR0durq6eXl53NzcNzc33t7e5+fnKCgoJycnISEhQUFBUVFRioqKyMjI1NTUd3d3DQ0NYmJiqqqqSEhIBQUFY2NjKioqREREEhIShoaGWqf6EwAAARBJREFUeJxjZCAAGIlQwAgCGCr/M/wHAZA4EytIASYASv/+B1LAzfj9L1bTmTn/fwUp4P3/BYf9PIyfQQpYOT/hUMD3/TdIAT/jBxwKBP5/BCkQYMCpAChDrAJBxnfCjG8YRF8zMIgxMr5gkGR8Js34BEmBLOMjecYHDIr3GXjE7infZZDiuqP6+gOSAjVgWH0HK9BifCrDeFmP8ed/zgtYTTD8zMfIeAbDBIQCU6BZp/5hKKCaNy3fCx1jsH7LIHLElvEQigKoG+wPAvU5MO4HxqDpPhQFUG86PxU+yuDC+OU4hgKCJkAVOD+V2wU04THHBVanhwo7qOZNggmGYJIjmGgJJnuCGYdg1sMPCCoAALwpliGQW5iZAAAAAElFTkSuQmCC"),
                    (go) => ToggleGUI()
                );
            }
        }

        public void ToggleGUI()
        {
            mainWindow.Visible = !mainWindow.Visible;
        }

        public void ImportConfigsAndUpdate(string ConfigName)
        {
            ImportConfiguration(ref EditModeConfig, ConfigName);
            mainWindow.UpdateEditModeValues();
        }

        private static Dictionary<string, ShoeConfig> LoadShoeDatabase()
        {
            var database = new Dictionary<string, ShoeConfig>(
                StringComparer.OrdinalIgnoreCase
            );

            if (!Directory.Exists(ShoeConfigPath))
                Directory.CreateDirectory(ShoeConfigPath);

            var shoeConfigs = Directory.GetFiles(ShoeConfigPath, "*hhmod_*.json", SearchOption.AllDirectories);

            foreach (var configPath in shoeConfigs)
                try
                {
                    var fileNameWithoutExt = Path.GetFileNameWithoutExtension(configPath);

                    // Extract the configuration name from the shoe name
                    var key = Core.Utility.ExtractShoeConfigName(fileNameWithoutExt);

                    if (string.IsNullOrEmpty(key))
                    {
                        Instance!.Logger.LogWarning($"No 'hhmod_' found in filename: {configPath}");
                        continue;
                    }

                    if (database.ContainsKey(key))
                    {
                        Instance!.Logger.LogWarning($"Duplicate configuration filename found: {configPath}. Skipping");
                        continue;
                    }

                    Instance!.Logger.LogDebug($"loading configuration, filename: {configPath}");
                    Instance!.Logger.LogDebug($"loading configuration, key: {key}");
                    var configJson = File.ReadAllText(configPath);
                    database[key] = JsonConvert.DeserializeObject<ShoeConfig>(configJson);
                }
                catch (Exception e)
                {
                    var errorVerb = e is IOException ? "load" : "parse";
                    Instance!.Logger.LogWarning($"Could not {errorVerb} '{configPath}' because: {e.Message}");
                }

            return database;
        }

        private static void ExportConfiguration(ShoeConfig config, string filename)
        {
            try
            {
                if (!Directory.Exists(ShoeConfigPath)) Directory.CreateDirectory(ShoeConfigPath);

                var fullPath = CreateConfigFullPath(filename);

                var jsonText = JsonConvert.SerializeObject(config, Formatting.Indented);

                File.WriteAllText(fullPath, jsonText);
                Instance!.Logger.LogInfo($"Configuration exported successfully to {fullPath}");
            }
            catch (Exception e)
            {
                Instance!.Logger.LogError($"Failed to export configuration to {filename}. Reason: {e.Message}");
            }
        }

        private static void ImportConfiguration(ref ShoeConfig config, string filename)
        {
            try
            {
                var fullPath = CreateConfigFullPath(filename);

                if (!File.Exists(fullPath))
                {
                    Instance!.Logger.LogWarning(
                        $"Configuration file {fullPath} not found. Using default configuration.");
                    return;
                }

                var jsonText = File.ReadAllText(fullPath);

                var importedConfig = JsonConvert.DeserializeObject<ShoeConfig>(jsonText);

                if (importedConfig == null)
                    throw new JsonSerializationException("Deserialized configuration object is null.");

                config = importedConfig;
                Instance!.Logger.LogInfo($"Configuration imported successfully from {fullPath}");
            }
            catch (Exception e)
            {
                Instance!.Logger.LogError($"Failed to import configuration from {filename}. Reason: {e.Message}");
                Instance!.Logger.LogWarning("Using default configuration due to import failure.");
                config = new ShoeConfig();
            }
        }


        private static string CreateConfigFullPath(string filename)
        {
            var sanitizedFilename = SanitizeFilename(filename.ToLowerInvariant());

            if (string.IsNullOrEmpty(sanitizedFilename))
                sanitizedFilename = "hhmod_configuration";
            else if (!sanitizedFilename.StartsWith("hhmod_"))
                sanitizedFilename = "hhmod_" + sanitizedFilename;

            sanitizedFilename += ".json";

            return Path.Combine(ShoeConfigPath, sanitizedFilename);

            static string SanitizeFilename(string path)
            {
                var invalid = Path.GetInvalidFileNameChars();
                path = path.Trim();
                return string.Join("_", path.Split(invalid)).Replace(".", "").Trim('_');
            }
        }

        public void LoadBodyOffsetConfig()
        {
            try
            {
                if (File.Exists(BodyOffsetConfigPath))
                {
                    var jsonText = File.ReadAllText(BodyOffsetConfigPath);

                    BodyOffsets = JsonConvert.DeserializeObject<BodyOffsetConfig>(jsonText);

                    if (BodyOffsets == null) throw new JsonSerializationException("Deserialized object is null.");
                }
                else
                {
                    Logger.LogWarning("BodyOffsetConfig file not found. Creating a new one.");
                    BodyOffsets = new BodyOffsetConfig();
                    SaveBodyOffsetConfig();
                }
            }
            catch (Exception e)
            {
                Logger.LogError($"Failed to load BodyOffsetConfig. Reason: {e.Message}");
                Logger.LogWarning("Creating a new BodyOffsetConfig file.");
                BodyOffsets = new BodyOffsetConfig();
                SaveBodyOffsetConfig();
            }
        }

        public void SaveBodyOffsetConfig()
        {
            try
            {
                var jsonText = JsonConvert.SerializeObject(BodyOffsets, Formatting.Indented);
                File.WriteAllText(BodyOffsetConfigPath, jsonText);
            }
            catch (Exception e)
            {
                Instance!.Logger.LogError(
                    $"Failed to SaveBodyOffsetConfig to {BodyOffsetConfigPath}. Reason: {e.Message}");
            }
        }
    }
}