using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using COM3D2.HighHeel.Core;
using COM3D2.HighHeel.UI;
using HarmonyLib;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.HighHeel
{
	// Token: 0x02000006 RID: 6
	[NullableContext(1)]
	[Nullable(0)]
	[BepInPlugin("com.ongame.com3d2.highheel", "COM3D2.HighHeel", "1.0.1")]
	public class Plugin : BaseUnityPlugin
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000208E File Offset: 0x0000028E
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002095 File Offset: 0x00000295
		public static bool IsDance { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000209D File Offset: 0x0000029D
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020A5 File Offset: 0x000002A5
		public Dictionary<string, ShoeConfig> ShoeDatabase { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020AE File Offset: 0x000002AE
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020B6 File Offset: 0x000002B6
		public bool EditMode { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020BF File Offset: 0x000002BF
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020C6 File Offset: 0x000002C6
		[Nullable(2)]
		public static Plugin Instance { [NullableContext(2)] get; [NullableContext(2)] private set; }


		private static readonly string BodyOffsetConfigPath = Path.Combine(ConfigPath, "Bodyoffset.json");
        public Core.BodyOffsetConfig BodyOffsets { get; private set; }

		// Token: 0x0600000D RID: 13 RVA: 0x000020D0 File Offset: 0x000002D0
		public Plugin()
		{
			Plugin.Instance = this;
			Harmony.CreateAndPatchAll(typeof(Hooks), null);
			LoadBodyOffsetConfig();
			this.Configuration = new PluginConfig(new ConfigFile(Path.Combine(Plugin.ConfigPath, "Configuration.cfg"), false, base.Info.Metadata));
			this.Logger = base.Logger;
			this.mainWindow = new MainWindow();
			this.mainWindow.ReloadEvent += delegate(object _, EventArgs _)
			{
				this.ShoeDatabase = Plugin.LoadShoeDatabase();
			};
			this.mainWindow.ExportEvent += delegate(object _, [Nullable(1)] TextInputEventArgs args)
			{
				Plugin.ExportConfiguration(this.EditModeConfig, args.Text);
			};
			this.mainWindow.ImportEvent += delegate(object _, [Nullable(1)] TextInputEventArgs args)
			{
				this.ImportConfigsAndUpdate(args.Text);
			};
			SceneManager.sceneLoaded += delegate(Scene _, LoadSceneMode _)
			{
				Plugin.IsDance = (Object.FindObjectOfType<DanceMain>() != null);
			};
			this.ShoeDatabase = Plugin.LoadShoeDatabase();
			this.ImportConfigsAndUpdate("");
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021C6 File Offset: 0x000003C6
		public void ImportConfigsAndUpdate(string ConfigName)
		{
			Plugin.ImportConfiguration(ref this.EditModeConfig, ConfigName);
			this.mainWindow.UpdateEditModeValues();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021E0 File Offset: 0x000003E0
		private void Update()
		{
			if (this.Configuration.UIShortcut.Value.IsUp())
			{
				this.mainWindow.Visible = !this.mainWindow.Visible;
			}
			this.mainWindow.Update();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000222B File Offset: 0x0000042B
		private void OnGUI()
		{
			this.mainWindow.Draw();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002238 File Offset: 0x00000438
		private static Dictionary<string, ShoeConfig> LoadShoeDatabase()
		{
			Dictionary<string, ShoeConfig> dictionary = new Dictionary<string, ShoeConfig>(StringComparer.OrdinalIgnoreCase);
			if (!Directory.Exists(Plugin.ShoeConfigPath))
			{
				Directory.CreateDirectory(Plugin.ShoeConfigPath);
			}
			foreach (string text in Directory.GetFiles(Plugin.ShoeConfigPath, "hhmod_*.json", SearchOption.AllDirectories))
			{
				try
				{
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
					if (dictionary.ContainsKey(fileNameWithoutExtension))
					{
						Plugin.Instance.Logger.LogWarning("Duplicate configuration filename found: " + text + ". Skipping");
					}
					else
					{
						string text2 = File.ReadAllText(text);
						dictionary[fileNameWithoutExtension] = JsonConvert.DeserializeObject<ShoeConfig>(text2);
					}
				}
				catch (Exception ex)
				{
					string text3 = (ex is IOException) ? "load" : "parse";
					Plugin.Instance.Logger.LogWarning(string.Concat(new string[]
					{
						"Could not ",
						text3,
						" '",
						text,
						"' because: ",
						ex.Message
					}));
				}
			}
			return dictionary;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002350 File Offset: 0x00000550
		private static void ExportConfiguration(ShoeConfig config, string filename)
		{
			if (!Directory.Exists(Plugin.ShoeConfigPath))
			{
				Directory.CreateDirectory(Plugin.ShoeConfigPath);
			}
			string path = Plugin.CreateConfigFullPath(filename);
			string contents = JsonConvert.SerializeObject(config, 1);
			File.WriteAllText(path, contents);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002388 File Offset: 0x00000588
		private static void ImportConfiguration(ref ShoeConfig config, string filename)
		{
			string path = Plugin.CreateConfigFullPath(filename);
			if (!File.Exists(path))
			{
				return;
			}
			string text = File.ReadAllText(path);
			config = JsonConvert.DeserializeObject<ShoeConfig>(text);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000023B4 File Offset: 0x000005B4
		private static string CreateConfigFullPath(string filename)
		{
			string text = Plugin.<CreateConfigFullPath>g__SanitizeFilename|34_0(filename.ToLowerInvariant());
			if (string.IsNullOrEmpty(text))
			{
				text = "hhmod_configuration";
			}
			else if (!text.StartsWith("hhmod_"))
			{
				text = "hhmod_" + text;
			}
			text += ".json";
			return Path.Combine(Plugin.ShoeConfigPath, text);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002468 File Offset: 0x00000668
		[CompilerGenerated]
		internal static string <CreateConfigFullPath>g__SanitizeFilename|34_0(string path)
		{
			char[] invalidFileNameChars = Path.GetInvalidFileNameChars();
			path = path.Trim();
			return string.Join("_", path.Split(invalidFileNameChars)).Replace(".", "").Trim(new char[]
			{
				'_'
			});
		}

		// Token: 0x04000003 RID: 3
		public const string PluginGuid = "com.ongame.com3d2.highheel";

		// Token: 0x04000004 RID: 4
		public const string PluginName = "COM3D2.HighHeel";

		// Token: 0x04000005 RID: 5
		public const string PluginVersion = "1.0.0";

		// Token: 0x04000006 RID: 6
		public const string PluginString = "COM3D2.HighHeel 1.0.0";

		// Token: 0x04000007 RID: 7
		private const string ConfigName = "Configuration.cfg";

		// Token: 0x04000008 RID: 8
		private static readonly string ConfigPath = Path.Combine(Paths.ConfigPath, "COM3D2.HighHeel");

		// Token: 0x04000009 RID: 9
		private static readonly string ShoeConfigPath = Path.Combine(Plugin.ConfigPath, "Configurations");

		// Token: 0x0400000A RID: 10
		public readonly PluginConfig Configuration;

		// Token: 0x0400000B RID: 11
		public readonly ManualLogSource Logger;

		// Token: 0x0400000C RID: 12
		private readonly MainWindow mainWindow;

		// Token: 0x0400000F RID: 15
		public ShoeConfig EditModeConfig = new ShoeConfig();



        public void LoadBodyOffsetConfig() {
            if (File.Exists(BodyOffsetConfigPath)) {
                string jsonText = File.ReadAllText(BodyOffsetConfigPath);
                BodyOffsets = JsonConvert.DeserializeObject<Core.BodyOffsetConfig>(jsonText);
            } else {
                BodyOffsets = new Core.BodyOffsetConfig();
            }
        }

        public void SaveBodyOffsetConfig() {
            string jsonText = JsonConvert.SerializeObject(BodyOffsets, Formatting.Indented);
            File.WriteAllText(BodyOffsetConfigPath, jsonText);
        }
	}
}
