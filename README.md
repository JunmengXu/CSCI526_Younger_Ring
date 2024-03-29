# CSCI526_Younger_Ring
WebGL Link: https://play.unity.com/mg/other/webgl-builds-250123

###### How to run this project?

Clone the project, open it in Unity Hub. Then, locate and open SampleScene under the `Assets/Scenes/` folder in the editor.

### Assets Folder Structure
    .
    ├── Prefabs                 # Reusable prefabs such as tiles and wall
    ├── Scenes                  # Scence files
    ├── Scripts                 # C# scripts
    └── TextMesh Pro            # Fonts and materials imported by default

### Scene Hierarchy
Currently there is only one scene.
> SampleScene.unity

    .
    ├── Player                  # The player
    ├── UI Canvas               # Canvas that holds all the UI elements
    │   ├── UIController        # It holds all the C# scripts that control the UI display
    │   ├── NextColorText       # The "Next Color: " text on the top left
    │   ├── ColorIndicator      # The "●" dot color indicator
    │   ├── Timer               # Timer text appears on the top right
    │   └── ResultScreen        # This screen will be set to active when game over
    ├── EventSystem             # Created by default
    ├── Environment             # Holds enviroment objects
    │   ├── ...
    │   ├── Floor
    │   ├── Wall
    │   ├── FinishLine
    │   └── ...
    ├── Tiles                   # Holds all the colorful tile blocks
    │   ├── ...
    │   ├── RedTile
    │   ├── GreenTile
    │   ├── BlueTile
    │   └── ...
    └── Cameras                 # Cameras

### Tag list
- 0: Floor
- 1: Tile
- 2: Wall
- 3: FinishLine
- 4: Item
- 5: Catapult
- 6: NoColorTile
- 7: ColorAdd

### Layer list
- 0: Default
- 1: TransparentFX
- 2: Ignore Raycast
- 4: Water
- 5: UI
- 6: Tiles
- 7: Floor
- 8: Wall
- 9: Item
- 10: White
- 11: Black
- 12: Red
- 13: Green
- 14: Blue
- 15: Obstacle
- 16: Fragile
- 17: AllColor
- 18: NoColor

### Scene list
- 0: Scenes/LevelMenu
- 1: Scenes/FirstLevelScene
- 2: Scenes/SecondLevel1
- 3: Scenes/SampleScene
- 4: Scenes/Level3
- 5: Scenes/Catapult_1
- 6: Scenes/Catapult_2
- 7: Scenes/Catapult_3
- 8: Scenes/Brush_1
- 9: Scenes/Wind_1
- 10: Scenes/Wind_2
- 11: Scenes/Wind_3
- 12: Scenes/Wind_4
- 13: Scenes/limitedJump_1
- 14: Scenes/limitedJump_2
- 15: Scenes/Obstacle1Scene
- 16: Scenes/ColorAdd_1
- 17: Scenes/ColorAdd_2

### Tweak Settings
To change the player's jump speed, tweak "Jump Force" and "Gravity".
![](https://github.com/MikeShuyang/misc/raw/main/player%20settings.jpg)

To change the color set, tweak "Color Set Selection".
![](https://github.com/MikeShuyang/misc/raw/main/color%20set%20setting.jpg)

### Level Index List
(Base on build list)
```
0       LevelMenu
1       FirstLevelScene
2       SecondLevel1
3       SampleScene
4       Level3              [SuperItem]
5       Catapult_1
6       Catapult_2
7       Catapult_3
8       Brush_1
9       Brush_2
10      Brush_3
11      Wind_1
12      Wind_2
13      Wind_3
14      Wind_4
15      fragile_1
16      fragile_2
17      Obstacle1Scene
18      ColorAdd_1
19      ColorAdd_2
20      Mix_1               [Catapult, Obstacle, Magnetic]
21      Night_1
22      ColorAddWind_1      [Wind, ColorAdd]
23      Magnet Tutorial
24      NightColorAdd_1     [Night, ColorAdd]
25      Mix_Brush_Catapult_Magnet   [Catapult, Magnetic, Brush]
26      SuperItem_1
27      magnetFramework     [Obstacle,Fragile, Magnetic]
```


### Bugs
1. ~~Player can go inside or even fall through other objects when the vertical velocity is too high, because the current implementation doesn't utilize Unity's physics system.~~
2. ~~(A good glitch for players) When the player falls on the side wall of a "Floor" or a "Tile" with the correct color, the player will be treated as grounded hence will jump again immediately.~~

### Potential Next Steps
* Implement a global game controller, lift some states up.
* Add a simple tutorial gif at the start of the game.
* Add collectable items.
