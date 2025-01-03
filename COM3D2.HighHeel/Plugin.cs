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

[assembly: AssemblyVersion("1.0.8.2")]

namespace COM3D2.Highheel.Plugin;

[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Plugin : BaseUnityPlugin
{
    public const string PluginGuid = "com.ongame.com3d2.highheel";
    public const string PluginName = "COM3D2.HighHeel";
    public const string PluginVersion = "1.0.8.2";
    public const string PluginString = PluginName + " " + PluginVersion;

    private const string ConfigName = "Configuration.cfg";

    private static readonly string ConfigPath = Path.Combine(Paths.ConfigPath, PluginName);
    private static readonly string ShoeConfigPath = Path.Combine(ConfigPath, "Configurations");

    private static readonly string BodyOffsetConfigPath = Path.Combine(
        ConfigPath,
        "Bodyoffset.json"
    );

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

        Configuration = new PluginConfig(new ConfigFile(Path.Combine(ConfigPath, ConfigName), false, Info.Metadata));
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
            //ImportConfiguration(ref EditModeConfig, args.Text);
            //mainWindow.UpdateEditModeValues();
        };

        SceneManager.sceneLoaded += (_, _) => IsDance = FindObjectOfType<DanceMain>() != null;

        ShoeDatabase = LoadShoeDatabase();

        ImportConfigsAndUpdate("");
        //ImportConfiguration(ref EditModeConfig, "");
        //mainWindow.UpdateEditModeValues();
    }

    public static bool IsDance { get; private set; }

    public Dictionary<string, ShoeConfig> ShoeDatabase { get; private set; }

    public bool EditMode { get; set; }

    public static Plugin Instance { get; private set; }

    public BodyOffsetConfig BodyOffsets { get; private set; }

    private void Update()
    {
        if (Configuration.UIShortcut.Value.IsUp())
            mainWindow.Visible = !mainWindow.Visible;

        mainWindow.Update();
    }

    private void OnGUI()
    {
        mainWindow.Draw();
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

        var shoeConfigs = Directory.GetFiles(
            ShoeConfigPath,
            "hhmod_*.json",
            SearchOption.AllDirectories
        );

        foreach (var configPath in shoeConfigs)
            try
            {
                var key = Path.GetFileNameWithoutExtension(configPath);

                if (database.ContainsKey(key))
                {
                    Instance!.Logger.LogWarning(
                        $"Duplicate configuration filename found: {configPath}. Skipping"
                    );
                    continue;
                }

                var configJson = File.ReadAllText(configPath);
                database[key] = JsonConvert.DeserializeObject<ShoeConfig>(configJson);
            }
            catch (Exception e)
            {
                var errorVerb = e is IOException ? "load" : "parse";
                Instance!.Logger.LogWarning(
                    $"Could not {errorVerb} '{configPath}' because: {e.Message}"
                );
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