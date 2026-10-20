#!/usr/bin/env python3
# -*- coding: utf-8 -*-
# Function: 组装发布 zip / Assemble the release zip
"""组装发布 zip。

每个游戏版本一个包，解压到对应游戏的根目录即可，包内布局与插件运行时读取的路径一致：

    BepInEx/plugins/COM3D2.Highheel.Plugin.dll    （2.x）
    BepInEx/plugins/COM3D25.Highheel.Plugin.dll   （3.x）
    README.md

两个版本的 dll 名不同，压缩包也直接用各自的插件名，所以装错了也能一眼看出来。

**只打包插件本体这一个 dll，不做目录通配。**
`bin/Release/<target>/<tfm>/` 里还会躺着 `Assembly-CSharp.dll`、`Assembly-CSharp-firstpass.dll`、
`UnityEngine.UI.dll`、`Newtonsoft.Json.dll` —— 这些是编译期引用被顺带复制进来的，
游戏目录里本来就有（而且版本更匹配），打进包里覆盖过去只会把游戏弄坏。

One archive per game version, each mirroring the layout the plugin expects after
extracting into that game's root. The two builds use different assembly names and each
archive is named after its own plugin, so a wrong download is obvious at a glance.
Only the plugin dll is packaged, deliberately not a directory glob: the build output also
contains the game assemblies and Newtonsoft.Json that got copied there as compile-time
references, and overwriting the game's own copies would break it.
"""

import argparse
import os
import sys
import zipfile

# 目标定义：bin/Release 下的子目录、插件 dll 名、zip 前缀
# 两个版本的 dll 名不同（COM3D2. / COM3D25. 前缀），压缩包也直接用各自的插件名
# Per target: build subdirectory, plugin dll name and zip prefix. The two builds use
# different assembly names, and each archive is named after its own plugin.
TARGETS = {
    "COM3D2": {
        "build_dir": "COM3D2/net35",
        "dll": "COM3D2.Highheel.Plugin.dll",
        "prefix": "COM3D2.Highheel.Plugin",
    },
    "COM3D25": {
        "build_dir": "COM3D25/net48",
        "dll": "COM3D25.Highheel.Plugin.dll",
        "prefix": "COM3D25.Highheel.Plugin",
    },
}

PLUGIN_DIR_IN_ZIP = "BepInEx/plugins"

# 固定时间戳，保证同样的输入产出同样的 zip / Fixed timestamp so identical inputs give identical zips
FIXED_DATE_TIME = (2020, 1, 1, 0, 0, 0)


def add_dir(zf, name):
    info = zipfile.ZipInfo(name.rstrip("/") + "/", date_time=FIXED_DATE_TIME)
    info.external_attr = (0o40755 << 16) | 0x10
    info.compress_type = zipfile.ZIP_STORED
    zf.writestr(info, b"")


def add_file(zf, src, arcname):
    info = zipfile.ZipInfo(arcname, date_time=FIXED_DATE_TIME)
    info.external_attr = 0o100644 << 16
    info.compress_type = zipfile.ZIP_DEFLATED
    with open(src, "rb") as f:
        zf.writestr(info, f.read(), compresslevel=9)


def main():
    parser = argparse.ArgumentParser(description="Assemble the release zip")
    parser.add_argument("--target", required=True, choices=sorted(TARGETS),
                        help="COM3D2 (2.x) 或 COM3D25 (3.x) / which game the archive is for")
    parser.add_argument("--version", required=True, help="例如 1.0.9.2 / e.g. 1.0.9.2")
    parser.add_argument("--build-root", required=True,
                        help="dotnet build 的输出根目录（bin/Release）/ dotnet build output root")
    parser.add_argument("--repo-root", default=".", help="仓库根目录 / repository root")
    parser.add_argument("--output-dir", default="dist", help="zip 输出目录 / output directory")
    args = parser.parse_args()

    repo_root = os.path.abspath(args.repo_root)
    target = TARGETS[args.target]
    plugin_dll_name = target["dll"]
    build_dir = os.path.join(os.path.abspath(args.build_root), target["build_dir"])
    plugin_dll = os.path.join(build_dir, plugin_dll_name)
    readme = os.path.join(repo_root, "README.md")

    if not os.path.isfile(plugin_dll):
        found = sorted(os.listdir(build_dir)) if os.path.isdir(build_dir) else []
        sys.exit(f"::error::{plugin_dll_name} not found in {build_dir}, got {found}")
    if not os.path.isfile(readme):
        sys.exit(f"::error::missing file: {readme}")

    os.makedirs(os.path.join(repo_root, args.output_dir), exist_ok=True)
    zip_path = os.path.join(
        repo_root, args.output_dir, f"{target['prefix']}-{args.version}.zip")

    with zipfile.ZipFile(zip_path, "w", zipfile.ZIP_DEFLATED, compresslevel=9) as zf:
        add_dir(zf, "BepInEx")
        add_dir(zf, PLUGIN_DIR_IN_ZIP)
        add_file(zf, plugin_dll, f"{PLUGIN_DIR_IN_ZIP}/{plugin_dll_name}")
        add_file(zf, readme, "README.md")

    # 自检：条目必须正好是这两个，多一个少一个都算打包逻辑坏了
    # Sanity check: exactly these two entries, nothing more and nothing less
    with zipfile.ZipFile(zip_path) as zf:
        names = zf.namelist()
    expected = {
        "BepInEx/",
        f"{PLUGIN_DIR_IN_ZIP}/",
        f"{PLUGIN_DIR_IN_ZIP}/{plugin_dll_name}",
        "README.md",
    }
    unexpected = sorted(set(names) - expected)
    if unexpected:
        sys.exit(f"::error::unexpected entries in {zip_path}: {unexpected}")
    if f"{PLUGIN_DIR_IN_ZIP}/{plugin_dll_name}" not in names:
        sys.exit(f"::error::{plugin_dll_name} missing from {zip_path}")

    size = os.path.getsize(zip_path)
    print(f"built {zip_path} ({len(names)} entries, {size} bytes)")


if __name__ == "__main__":
    main()
