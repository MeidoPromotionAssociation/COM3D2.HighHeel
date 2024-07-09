using System;
using System.Runtime.CompilerServices;
using BepInEx.Configuration;
using UnityEngine;

namespace COM3D2.HighHeel
{
	// Token: 0x02000007 RID: 7
	[NullableContext(1)]
	[Nullable(0)]
	public class PluginConfig
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000024B3 File Offset: 0x000006B3
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000024BB File Offset: 0x000006BB
		public ConfigEntry<bool> Enabled { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001C RID: 28 RVA: 0x000024C4 File Offset: 0x000006C4
		// (set) Token: 0x0600001D RID: 29 RVA: 0x000024CC File Offset: 0x000006CC
		public ConfigEntry<KeyboardShortcut> UIShortcut { get; private set; }

		// Token: 0x0600001E RID: 30 RVA: 0x000024D8 File Offset: 0x000006D8
		public PluginConfig(ConfigFile config)
		{
			this.Enabled = config.Bind<bool>("Config", "Enabled", true, "Plugin enabled");
			this.UIShortcut = config.Bind<KeyboardShortcut>("Config", "UIShortcut", new KeyboardShortcut(290, new KeyCode[]
			{
				306
			}), "Shortcut to toggle configuration UI");
		}
	}
}
