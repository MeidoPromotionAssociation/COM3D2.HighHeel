# COM3D2.HighHeel {{VERSION}}

Adjusts the foot and toe bones so a maid actually stands on her high heels instead of sinking into the floor.

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

See the [README](https://github.com/{{REPO}}/blob/main/README.md) for the full field reference, in English and Chinese.

# Changes

{{CHANGELOG}}

<br>
<br>
<br>

# 说明

本插件会调整脚和脚趾的骨骼，让女仆真正站在高跟鞋上，而不是陷进地面。

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

完整字段说明见 [README](https://github.com/{{REPO}}/blob/main/README.md)（中英双语）。

# 更改

{{CHANGELOG_ZH}}

**Full Changelog**: {{FULL_CHANGELOG_URL}}
