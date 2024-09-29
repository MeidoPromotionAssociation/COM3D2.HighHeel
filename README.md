# COM3D2.HighHeel-InoryS

Here is the version that allows you to set the BodyOffset for each scene, as I at least observed that different BodyOffsets were needed for the karaoke and "night scenes" to keep the maid from sinking into the ground.

You can also set the BodyOffset for the man so that he is aligned with the maid in the "night scene".

The configuration file will be generated in `COM3D2\BepInEx\config\COM3D2.HighHeel\Bodyoffset.json`

This is a sample of the config (You can't really leave comments in config files):
```
{
  "DefaultBodyOffset": 0.04,   //Default maid BodyOffset, If you do not set an BodyOffset for the scene individually, this value is applied.
  "DefaultManBodyOffset": 0.0,  //Default man BodyOffset, If you do not set an BodyOffset for the scene individually, this value is applied.
  "SceneSpecificOffsets": {
    "10": 0.05,    //This means setting the maid BodyOffset of scene index 10 to 0.05.
    "14": 0.05,    //This means setting the maid BodyOffset of scene index 14 to 0.05.
    "63": 0.05,
    "65": 0.06
  },
  "SceneSpecificManOffsets":{
    "10": 0.05,    //This means setting the man BodyOffset of scene index 10 to 0.05.
    "14": 0.05    //This means setting the man BodyOffset of scene index 14 to 0.05.
    "63": 0.05,
  }
}
```


| Scene index | Description |
| ----------- | ----------- |
| 10      | "night scene" in CBL version       |
| 14     | "night scene"       |
| 63     | exchange "night scene"   |
| 65     | karaoke   |


If you want to know the Sence index of the current scene, you can consider installing [COM3D2.DebugLilly.BepInExPlugin.dll](https://github.com/customordermaid3d2/COM3D2.Lilly.BepInExPlugin/releases)
It will tell you the Sence index and Sence name of the current scene in the console.


Note: BodyOffst in the original configuration file will be invalid. 

Currently, there is no GUI implemented. 



After changing it in the configuration file, you can click reload in the plugin settings, which will reload the configuration file.




<br>
<br>
<br>
<br>
<br>
<br>


这是允许您为每个场景设置 BodyOffset 的版本，因为我至少观察到卡拉 OK 和“夜景”需要不同的 BodyOffset，以防止女仆沉入地面。

您还可以为男人设置 BodyOffset，以便他在“夜景”中与女仆对齐。

配置文件将在 `COM3D2\BepInEx\config\COM3D2.HighHeel\Bodyoffset.json` 中生成

这是配置的示例（您实际上不能在配置文件中留下注释）：
```
{
 “DefaultBodyOffset”：0.04，//默认女仆 BodyOffset，如果您没有为场景单独设置 BodyOffset，则应用此值。
 “DefaultManBodyOffset”：0.0，//默认男人 BodyOffset，如果您没有为场景单独设置 BodyOffset，则应用此值。
 "SceneSpecificOffsets": {
 "10": 0.05, //表示将场景索引 10 的女仆 BodyOffset 设置为 0.05。
 "14": 0.05, //表示将场景索引 14 的女仆 BodyOffset 设置为 0.05。
 "63": 0.05,
 "65": 0.06
 },
 "SceneSpecificManOffsets":{
  "10": 0.05, //表示将场景索引 10 的男人 BodyOffset 设置为 0.05。
  "14": 0.05 //表示将场景索引 14 的男人 BodyOffset 设置为 0.05。
  "63": 0.05,
  }
}
```

| 场景索引 | 描述 |
| ----------- | ----------- |
| 10 | CBL 版本中的“夜景”|
| 14 | “夜景” |
| 63 | 交流 “夜景” |
| 65 | 卡拉OK |

如果你想知道当前场景的 Sence 索引，你可以考虑安装 [COM3D2.DebugLilly.BepInExPlugin.dll](https://github.com/customordermaid3d2/COM3D2.Lilly.BepInExPlugin/releases)
它会在控制台中告诉你当前场景的 Sence 索引和 Sence 名称。

注意：原配置文件中的 BodyOffst 将失效。

目前，没有实现 GUI。

在配置文件中更改后，你可以在插件设置中单击 reload，这将重新加载配置文件。










<br>
<br>
<br>
<br>
<br>
<br>








# COM3D2.HighHeel

Dynamically adjust maid's feet for high heels.

## Features

### A GUI editor to create high heel configurations for exporting

![GUI Editor](./img/gui_editor.png)

### Configuration association with model files

![Configuration Association](./img/config_association.png)

## Installation

Download latest release and extract contents of `BepInEx` into `COM3D2\BepInEx`
