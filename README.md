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

<details>

<summaryCOM3D2 2.40.0 中的场景列表summary>
```
| SceneIndex|   SceneName                 |
|-----|-----------------------------------|
| 0   | _cm3d21                           |
| 1   | SceneCharacterSelect              |
| 2   | SceneCompetitiveShow              |
| 3   | SceneDaily                        |
| 4   | SceneDance_DDFL_Release           |
| 5   | SceneEdit                         |
| 6   | SceneLogo                         |
| 7   | SceneMaidManagement               |
| 8   | SceneShop                         |
| 9   | SceneTitle                        |
| 10  | SceneTrophy                       |
| 11  | SceneTryInfo                      |
| 12  | SceneUserEdit                     |
| 13  | SceneWarning                      |
| 14  | SceneYotogi                       |
| 15  | SceneADV                          |
| 16  | SceneStartDaily                   |
| 17  | SceneToTitle                      |
| 18  | SceneSingleEffect                 |
| 19  | SceneStaffRoll                    |
| 20  | SceneDance_ETYL_Release           |
| 21  | SceneDanceSelect                  |
| 22  | SceneDance_SCL_Release            |
| 23  | SceneDeskCustomize                |
| 24  | SceneFreeModeSelect               |
| 25  | SceneMaidBattle                   |
| 26  | ScenePhotoMode                    |
| 27  | SceneDance_RTY_Release            |
| 28  | SceneEmpireLeague                 |
| 29  | SceneDance_KNT_Release            |
| 30  | SceneVRTouch                      |
| 31  | SceneDance_SSNK_Release           |
| 32  | AddSceneVRMiniGameAirPlane        |
| 33  | AddSceneVRMiniGameDarts           |
| 34  | AddSceneVRMiniGameWanage          |
| 35  | AddSceneVRMediaPlay               |
| 36  | SceneVRCommunication              |
| 37  | SceneDance_NMF_Release            |
| 38  | SceneDance_BLD_Release            |
| 39  | SceneDance_KAD_Release            |
| 40  | SceneFacilityManagement           |
| 41  | SceneFacilityPowerUp              |
| 42  | SceneScenarioSelect               |
| 43  | SceneDance_BLDT_Release           |
| 44  | SceneDance_KADT_Release           |
| 45  | SceneDance_NMFT_Release           |
| 46  | SceneBenchMarkSetting             |
| 47  | SceneCasino                       |
| 48  | SceneBlackJack                    |
| 49  | SceneCasinoSlot                   |
| 50  | SceneDance_LUM_Release            |
| 51  | SceneCasinoShop                   |
| 52  | SceneCreativeRoom                 |
| 53  | SceneKasizukiMainMenu             |
| 54  | SceneNetorareCheck                |
| 55  | SceneDance_MOE_Release            |
| 56  | SceneDance_SCLT_Release           |
| 57  | SceneDance_KNTT_Release           |
| 58  | SceneDance_MOE2_Release           |
| 59  | SceneDance_DDFLT_Release          |
| 60  | SceneDance_RTYT_Release           |
| 61  | SceneDance_MOET_Release           |
| 62  | SceneDance_LUMT_Release           |
| 63  | SceneYotogiOld                    |
| 64  | SceneDance_ETY21T_Release         |
| 65  | SceneDance_CKTCK_Release          |
| 66  | SceneDance_DDFLK_Release          |
| 67  | SceneDance_HHSK_Release           |
| 68  | SceneDance_RTYK_Release           |
| 69  | SceneDance_SCLK_Release           |
| 70  | SceneDance_SMTK_Release           |
| 71  | SceneDance_SUH_Release            |
| 72  | SceneDance_SUHT_Release           |
| 73  | SceneDance_BLDK_Release           |
| 74  | SceneDance_KADK_Release           |
| 75  | SceneDance_NMFK_Release           |
| 76  | SceneDance_MAP_Release            |
| 77  | SceneDance_MAPT_Release           |
| 78  | SceneDance_LUM_K_Release          |
| 79  | SceneDance_SUHK_Release           |
| 80  | SceneDance_MOEK_Release           |
| 81  | SceneEmpireLifeMode               |
| 82  | SceneDance_SDB_Release            |
| 83  | SceneDance_SDBT_Release           |
| 84  | SceneDance_FUA_P_Release          |
| 85  | SceneNPCEdit                      |
| 86  | SceneDance_1OY_Release            |
| 87  | SceneDance_1OYT_Release           |
| 88  | SceneDance_CGL_Release            |
| 89  | SceneDance_CGLT_Release           |
| 90  | SceneDance_NMFEnglish_Release     |
| 91  | SceneDance_NMFTEnglish_Release    |
| 92  | SceneDance_TYP_Release            |
| 93  | SceneDance_TYPT_Release           |
| 94  | ScenePrivate                      |
| 95  | ScenePrivateEventMode             |
| 96  | SceneDance_RTD_Release            |
| 97  | SceneDance_RTDS_Release           |
| 98  | SceneDance_RTDT_Release           |
| 99  | SceneDance_LOC_P_Release          |
| 100 | SceneDance_AIKS_K21_Release       |
| 101 | SceneDance_DGP_Release            |
| 102 | SceneDance_DGPT_Release           |
| 103 | SceneDance_SMT_L21_Release        |
| 104 | SceneDance_SMT_T21_Release        |
| 105 | SceneDance_HHSx4_T21_Release      |
| 106 | SceneDance_HHSx4_L21_Release      |
| 107 | SceneDance_REG_L21_Release        |
| 108 | SceneDance_REG_T21_Release        |
| 109 | SceneDance_SSEx3_L21_Release      |
| 110 | SceneDance_SSEx3_T21_Release      |
| 111 | SceneDance_RTD_K_Release          |
| 112 | SceneDance_SDB_K_Release          |
| 113 | SceneDance_DGPK_Release           |
| 114 | SceneScout                        |
| 115 | SceneDance_REG_K_Release          |
| 116 | SceneDance_1OY_K_Release          |
| 117 | SceneDance_MAP_K_2_Release        |
| 118 | SceneDance_SUM_L21_Release        |
| 119 | SceneDance_SUM_T21_Release        |
| 120 | SceneDance_AIKS_2_K21_Release     |
| 121 | SceneDance_KHG_T21_Release        |
| 122 | SceneDance_KHG_L21_Release        |
| 123 | SceneDance_SFD_L21_Release        |
| 124 | SceneDance_SFD_T21_Release        |
| 125 | SceneDance_MTD_3_E21_Release      |
| 126 | SceneDance_MTD_1_E21_Release      |
| 127 | SceneDance_CIL_Release            |
| 128 | SceneDance_CILT_Release           |
| 129 | SceneShooting                     |
| 130 | SceneDance_RUB_Release            |
| 131 | SceneDance_RUBT_Release           |
| 132 | SceneDance_CIL_K_Release          |
| 133 | SceneDance_RUB_K_Release          |
| 134 | SceneDance_NMF_K_boku_2_Release   |
| 135 | SceneDance_NMF_K_dos_2_Release    |
| 136 | SceneDance_NMF_K_majime_2_Release |
| 137 | SceneDance_NMF_K_muku_1_Release   |
| 138 | SceneDance_NMF_K_muku_2_Release   |
| 139 | SceneDance_NMF_K_rin_2_Release    |
| 140 | SceneDance_NMF_K_boku_4_Release   |
| 141 | SceneDance_NMF_K_dos_4_Release    |
| 142 | SceneDance_NMF_K_muku_3_Release   |
| 143 | SceneDance_NMF_K_muku_4_Release   |
| 144 | SceneDance_NMF_K_majime_4_Release |
| 145 | SceneDance_NMF_K_rin_4_Release    |
| 146 | SceneDance_CPM_K_2_Release        |
| 147 | SceneDance_CPM_K_1_Release        |
| 148 | SceneHoneymoonMode                |
| 149 | SceneEyecatch                     |
| 150 | SceneFishingGame                  |
| 151 | SceneAssSumo                      |
| 152 | SceneAssSumoSecond                |
| 153 | SceneTeikokusouRevivalMode        |
| 154 | SceneTeikokusouPlayMode           |
```


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



<details>

<summaryCOM3D2 2.40.0 中的场景列表summary>
```
| 场景索引|   场景名称                     |
|-----|-----------------------------------|
| 0   | _cm3d21                           |
| 1   | SceneCharacterSelect              |
| 2   | SceneCompetitiveShow              |
| 3   | SceneDaily                        |
| 4   | SceneDance_DDFL_Release           |
| 5   | SceneEdit                         |
| 6   | SceneLogo                         |
| 7   | SceneMaidManagement               |
| 8   | SceneShop                         |
| 9   | SceneTitle                        |
| 10  | SceneTrophy                       |
| 11  | SceneTryInfo                      |
| 12  | SceneUserEdit                     |
| 13  | SceneWarning                      |
| 14  | SceneYotogi                       |
| 15  | SceneADV                          |
| 16  | SceneStartDaily                   |
| 17  | SceneToTitle                      |
| 18  | SceneSingleEffect                 |
| 19  | SceneStaffRoll                    |
| 20  | SceneDance_ETYL_Release           |
| 21  | SceneDanceSelect                  |
| 22  | SceneDance_SCL_Release            |
| 23  | SceneDeskCustomize                |
| 24  | SceneFreeModeSelect               |
| 25  | SceneMaidBattle                   |
| 26  | ScenePhotoMode                    |
| 27  | SceneDance_RTY_Release            |
| 28  | SceneEmpireLeague                 |
| 29  | SceneDance_KNT_Release            |
| 30  | SceneVRTouch                      |
| 31  | SceneDance_SSNK_Release           |
| 32  | AddSceneVRMiniGameAirPlane        |
| 33  | AddSceneVRMiniGameDarts           |
| 34  | AddSceneVRMiniGameWanage          |
| 35  | AddSceneVRMediaPlay               |
| 36  | SceneVRCommunication              |
| 37  | SceneDance_NMF_Release            |
| 38  | SceneDance_BLD_Release            |
| 39  | SceneDance_KAD_Release            |
| 40  | SceneFacilityManagement           |
| 41  | SceneFacilityPowerUp              |
| 42  | SceneScenarioSelect               |
| 43  | SceneDance_BLDT_Release           |
| 44  | SceneDance_KADT_Release           |
| 45  | SceneDance_NMFT_Release           |
| 46  | SceneBenchMarkSetting             |
| 47  | SceneCasino                       |
| 48  | SceneBlackJack                    |
| 49  | SceneCasinoSlot                   |
| 50  | SceneDance_LUM_Release            |
| 51  | SceneCasinoShop                   |
| 52  | SceneCreativeRoom                 |
| 53  | SceneKasizukiMainMenu             |
| 54  | SceneNetorareCheck                |
| 55  | SceneDance_MOE_Release            |
| 56  | SceneDance_SCLT_Release           |
| 57  | SceneDance_KNTT_Release           |
| 58  | SceneDance_MOE2_Release           |
| 59  | SceneDance_DDFLT_Release          |
| 60  | SceneDance_RTYT_Release           |
| 61  | SceneDance_MOET_Release           |
| 62  | SceneDance_LUMT_Release           |
| 63  | SceneYotogiOld                    |
| 64  | SceneDance_ETY21T_Release         |
| 65  | SceneDance_CKTCK_Release          |
| 66  | SceneDance_DDFLK_Release          |
| 67  | SceneDance_HHSK_Release           |
| 68  | SceneDance_RTYK_Release           |
| 69  | SceneDance_SCLK_Release           |
| 70  | SceneDance_SMTK_Release           |
| 71  | SceneDance_SUH_Release            |
| 72  | SceneDance_SUHT_Release           |
| 73  | SceneDance_BLDK_Release           |
| 74  | SceneDance_KADK_Release           |
| 75  | SceneDance_NMFK_Release           |
| 76  | SceneDance_MAP_Release            |
| 77  | SceneDance_MAPT_Release           |
| 78  | SceneDance_LUM_K_Release          |
| 79  | SceneDance_SUHK_Release           |
| 80  | SceneDance_MOEK_Release           |
| 81  | SceneEmpireLifeMode               |
| 82  | SceneDance_SDB_Release            |
| 83  | SceneDance_SDBT_Release           |
| 84  | SceneDance_FUA_P_Release          |
| 85  | SceneNPCEdit                      |
| 86  | SceneDance_1OY_Release            |
| 87  | SceneDance_1OYT_Release           |
| 88  | SceneDance_CGL_Release            |
| 89  | SceneDance_CGLT_Release           |
| 90  | SceneDance_NMFEnglish_Release     |
| 91  | SceneDance_NMFTEnglish_Release    |
| 92  | SceneDance_TYP_Release            |
| 93  | SceneDance_TYPT_Release           |
| 94  | ScenePrivate                      |
| 95  | ScenePrivateEventMode             |
| 96  | SceneDance_RTD_Release            |
| 97  | SceneDance_RTDS_Release           |
| 98  | SceneDance_RTDT_Release           |
| 99  | SceneDance_LOC_P_Release          |
| 100 | SceneDance_AIKS_K21_Release       |
| 101 | SceneDance_DGP_Release            |
| 102 | SceneDance_DGPT_Release           |
| 103 | SceneDance_SMT_L21_Release        |
| 104 | SceneDance_SMT_T21_Release        |
| 105 | SceneDance_HHSx4_T21_Release      |
| 106 | SceneDance_HHSx4_L21_Release      |
| 107 | SceneDance_REG_L21_Release        |
| 108 | SceneDance_REG_T21_Release        |
| 109 | SceneDance_SSEx3_L21_Release      |
| 110 | SceneDance_SSEx3_T21_Release      |
| 111 | SceneDance_RTD_K_Release          |
| 112 | SceneDance_SDB_K_Release          |
| 113 | SceneDance_DGPK_Release           |
| 114 | SceneScout                        |
| 115 | SceneDance_REG_K_Release          |
| 116 | SceneDance_1OY_K_Release          |
| 117 | SceneDance_MAP_K_2_Release        |
| 118 | SceneDance_SUM_L21_Release        |
| 119 | SceneDance_SUM_T21_Release        |
| 120 | SceneDance_AIKS_2_K21_Release     |
| 121 | SceneDance_KHG_T21_Release        |
| 122 | SceneDance_KHG_L21_Release        |
| 123 | SceneDance_SFD_L21_Release        |
| 124 | SceneDance_SFD_T21_Release        |
| 125 | SceneDance_MTD_3_E21_Release      |
| 126 | SceneDance_MTD_1_E21_Release      |
| 127 | SceneDance_CIL_Release            |
| 128 | SceneDance_CILT_Release           |
| 129 | SceneShooting                     |
| 130 | SceneDance_RUB_Release            |
| 131 | SceneDance_RUBT_Release           |
| 132 | SceneDance_CIL_K_Release          |
| 133 | SceneDance_RUB_K_Release          |
| 134 | SceneDance_NMF_K_boku_2_Release   |
| 135 | SceneDance_NMF_K_dos_2_Release    |
| 136 | SceneDance_NMF_K_majime_2_Release |
| 137 | SceneDance_NMF_K_muku_1_Release   |
| 138 | SceneDance_NMF_K_muku_2_Release   |
| 139 | SceneDance_NMF_K_rin_2_Release    |
| 140 | SceneDance_NMF_K_boku_4_Release   |
| 141 | SceneDance_NMF_K_dos_4_Release    |
| 142 | SceneDance_NMF_K_muku_3_Release   |
| 143 | SceneDance_NMF_K_muku_4_Release   |
| 144 | SceneDance_NMF_K_majime_4_Release |
| 145 | SceneDance_NMF_K_rin_4_Release    |
| 146 | SceneDance_CPM_K_2_Release        |
| 147 | SceneDance_CPM_K_1_Release        |
| 148 | SceneHoneymoonMode                |
| 149 | SceneEyecatch                     |
| 150 | SceneFishingGame                  |
| 151 | SceneAssSumo                      |
| 152 | SceneAssSumoSecond                |
| 153 | SceneTeikokusouRevivalMode        |
| 154 | SceneTeikokusouPlayMode           |
```






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
