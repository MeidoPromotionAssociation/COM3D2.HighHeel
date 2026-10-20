# Note

This release ships two builds of the same plugin. **Download the one matching your game:**

- `COM3D2.Highheel.Plugin-COM3D2-{{VERSION}}.zip` — for COM3D2 (2.x, Unity 5.6)
- `COM3D2.Highheel.Plugin-COM3D25-{{VERSION}}.zip` — for COM3D2.5 (3.x, Unity 2022.3)

Both contain the same `COM3D2.Highheel.Plugin.dll`, so install only one of them.

# Install

Extract the zip into your game root, so that the file ends up at:

```
COM3D2/BepInEx/plugins/COM3D2.Highheel.Plugin.dll
```

Requirements: BepInEx 5.x. Nothing else has to be installed alongside it.

Start the game, put a pair of high heels on a maid, and the plugin picks up the shoe configuration automatically.

# Usage

- `Ctrl + F9` toggles the configuration window.
- Enable `AddGearMenuButton` in `Configuration.cfg` to get a button in the gear menu instead.

Settings live under `BepInEx/config/COM3D2.HighHeel/`:

```
Configuration.cfg        plugin options (hotkey, man offset, gear menu button, ...)
GlobalBodyOffset.json    per-scene ground clearance
Configurations/          one hhmod_*.json per shoe
```

On COM3D2.5 the game already has built-in high-heel support (`_heel` in the model file name). The plugin reuses it: the game handles the foot pose, and the plugin only tops up the difference to the angle in your configuration, then applies the toe angles and the ground clearance. Everything is configured the same way on both versions.

See the [README](https://github.com/{{REPO}}/blob/main/README.md) for the full field reference, in English and Chinese.

# Changes

{{CHANGELOG}}

<br>
<br>
<br>

# 说明

本次发布提供同一插件的两个版本，**请下载与你的游戏对应的那个**：

- `COM3D2.Highheel.Plugin-COM3D2-{{VERSION}}.zip` — 对应 COM3D2（2.x，Unity 5.6）
- `COM3D2.Highheel.Plugin-COM3D25-{{VERSION}}.zip` — 对应 COM3D2.5（3.x，Unity 2022.3）

两个包里的 `COM3D2.Highheel.Plugin.dll` 同名，只需安装其中一个。

# 安装

把 zip 解压到游戏根目录，最终文件位置应为：

```
COM3D2/BepInEx/plugins/COM3D2.Highheel.Plugin.dll
```

前置条件：BepInEx 5.x，不需要额外安装其它东西。

进入游戏给女仆穿上高跟鞋，插件会自动读取对应的鞋子配置。

# 使用

- `Ctrl + F9` 开关配置窗口。
- 在 `Configuration.cfg` 里打开 `AddGearMenuButton`，可以改成用齿轮菜单按钮打开。

配置位于 `BepInEx/config/COM3D2.HighHeel/`：

```
Configuration.cfg        插件选项（快捷键、男人 offset、齿轮菜单按钮等）
GlobalBodyOffset.json    逐场景的离地高度
Configurations/          每双鞋一个 hhmod_*.json
```

COM3D2.5 本身已经有高跟鞋支持（模型文件名里带 `_heel`）。插件复用它：脚部姿态交给游戏，插件只把配置角度与官方 25° 的差额补上，再负责脚趾造型和离地。两个版本的配置方式完全一样。

完整字段说明见 [README](https://github.com/{{REPO}}/blob/main/README.md)（中英双语）。

# 更改

{{CHANGELOG_ZH}}

**Full Changelog**: {{FULL_CHANGELOG_URL}}
