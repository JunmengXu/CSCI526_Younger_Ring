# CSCI526_Younger_Ring
WebGL Link: https://play.unity.com/mg/other/webgl-builds-244437

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

### Tweak Settings
To change the player's jump speed, tweak "Jump Force" and "Gravity".
![](https://github.com/MikeShuyang/misc/raw/main/player%20settings.jpg)

To change the color set, tweak "Color Set Selection".
![](https://github.com/MikeShuyang/misc/raw/main/color%20set%20setting.jpg)

### Bugs
1. ~~Player can go inside or even fall through other objects when the vertical velocity is too high, because the current implementation doesn't utilize Unity's physics system.~~
2. ~~(A good glitch for players) When the player falls on the side wall of a "Floor" or a "Tile" with the correct color, the player will be treated as grounded hence will jump again immediately.~~

### Potential Next Steps
* Implement a global game controller, lift some states up.
* Add a simple tutorial gif at the start of the game.
* Add collectable items.
