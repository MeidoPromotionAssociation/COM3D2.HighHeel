# COM3D2.HighHeel-InoryS

Here is the version that allows you to set the BodyOffset for each scene, as I at least observed that different BodyOffsets were needed for the karaoke and "night scenes" to keep the maid from sinking into the ground.

You can also set the BodyOffset for the man so that he is aligned with the maid in the "night scene".

The configuration file will be generated in `COM3D2\BepInEx\config\COM3D2.HighHeel\Bodyoffset.json`

This is a sample of the config:
```
{
  "DefaultBodyOffset": 0.04,   //Default Maid BodyOffset, If you do not set an BodyOffset for the scene individually, this value is applied.
  "DefaultManBodyOffset": 0.0,  //Default Man BodyOffset
  "SceneSpecificOffsets": {
    "10": 0.05,    //This means setting the maid BodyOffset of scene index 10 to 0.05
    "14": 0.05,    //This means setting the maid BodyOffset of scene index 14 to 0.05
    "63": 0.05,
    "65": 0.06
  },
  "SceneSpecificManOffsets":{
    "10": 0.05,    //This means setting the man BodyOffset of scene index 10 to 0.05
    "14": 0.05    //This means setting the man BodyOffset of scene index 14 to 0.05
    "63": 0.05,
  }
}
```


| Scene index | Description |
| ----------- | ----------- |
| 10      | "night scene"       |
| 14     | "night scene" in CBL version        |
| 63     | exchange "night scene"   |
| 65     | karaoke   |


If you want to know the Sence index of the current scene, you can consider installing [COM3D2.DebugLilly.BepInExPlugin.dll](https://github.com/customordermaid3d2/COM3D2.Lilly.BepInExPlugin/releases)
It will tell you the Sence index and Sence name of the current scene in the console.



<br>
<br>
<br>
<br>
<br>
<br>










Dynamically adjust maid's feet for high heels.

## Features

### A GUI editor to create high heel configurations for exporting

![GUI Editor](./img/gui_editor.png)

### Configuration association with model files

![Configuration Association](./img/config_association.png)

## Installation

Download latest release and extract contents of `BepInEx` into `COM3D2\BepInEx`
