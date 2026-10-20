#!/usr/bin/env python3
# -*- coding: utf-8 -*-
# Function: 读取插件版本号 / Print the plugin version
"""打印插件版本号。

唯一来源是 Plugin.cs 的 `public const string PluginVersion` 常量：
- BepInEx 元数据、游戏里显示的版本取它；
- 程序集版本由 csproj 用同样的正则从该常量推导（GenerateAssemblyInfo=true + <Version>）。

所以发版时只需要改这一处，再打一个同名 tag。本脚本把它和 tag 比对，
避免漏改版本号却照样发出包。

The single source is the PluginVersion constant in Plugin.cs: BepInEx metadata and
the in-game version read it, and the csproj derives the assembly version from the
same constant. A release compares it against the tag so a forgotten bump fails the
build instead of shipping a wrong version.
"""

import os
import re
import sys

PLUGIN_CS = os.path.join("COM3D2.HighHeel", "Plugin.cs")

PLUGIN_VERSION_PATTERN = re.compile(
    r'public\s+const\s+string\s+PluginVersion\s*=\s*"([^"]+)"')


def main():
    if not os.path.isfile(PLUGIN_CS):
        sys.exit(f"::error::file not found: {PLUGIN_CS}")

    with open(PLUGIN_CS, encoding="utf-8-sig") as f:
        match = PLUGIN_VERSION_PATTERN.search(f.read())

    if not match:
        sys.exit(f"::error::PluginVersion constant not found in {PLUGIN_CS}")

    print(match.group(1))


if __name__ == "__main__":
    main()
