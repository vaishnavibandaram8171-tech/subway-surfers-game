# Subway Surfers Game - Project Setup Guide

## Scene Setup Instructions

### 1. Create Tags
Add these tags in Edit > Project Settings > Tags and Layers:
- `Player`
- `Ground`
- `Obstacle`
- `Coin`

### 2. Create Layers
Add these layers in Edit > Project Settings > Layers:
- `Player`
- `Ground`
- `Obstacles`
- `Coins`

### 3. Scene Hierarchy Setup

```
Scene
├── Player
│   ├── Capsule (Model)
│   ├── Rigidbody
│   ├── Collider
│   ├── PlayerController Script
│   └── Camera (Child)
├── Ground
│   ├── Cube (repeated)
│   └── Box Collider
├── Canvas (UI)
│   ├── Score Text
│   ├── Coins Text
│   ├── GameOver Panel
│   └── Restart Button
└── Managers
    ├── GameManager (with GameManager script)
    ├── WorldGenerator (with WorldGenerator script)
    ├── CameraController (with CameraController script)
    └── AudioManager (with AudioManager script)
```

### 4. Player Setup
1. Create a Capsule (or import a 3D model)
2. Add Component > Rigidbody
   - Freeze Rotation: X, Y, Z
   - Gravity: Enabled
3. Add Component > Capsule Collider
4. Add Component > PlayerController Script
5. Assign Layer: "Player"
6. Add "Player" tag

### 5. Ground Tile Setup
1. Create a Cube
2. Scale it: X=10, Y=0.5, Z=10
3. Add Box Collider
4. Create Material (Optional: add color)
5. Add "Ground" tag
6. Save as Prefab: Assets/Prefabs/GroundTile

### 6. Obstacle Setup
1. Create a Cube
2. Scale it: X=2, Y=1, Z=2
3. Add Box Collider with "Is Trigger" enabled
4. Add Component > Obstacle Script
5. Add "Obstacle" tag
6. Change Layer to "Obstacles"
7. Save as Prefab: Assets/Prefabs/Obstacle

### 7. Coin Setup
1. Create a Cylinder (or use a custom model)
2. Scale it appropriately: X=0.5, Y=0.2, Z=0.5
3. Add Sphere Collider with "Is Trigger" enabled
4. Add Component > Coin Script
5. Add "Coin" tag
6. Save as Prefab: Assets/Prefabs/Coin

### 8. UI Canvas Setup
1. Create Canvas (Right-click > UI > Canvas)
2. Add Text Elements:
   - Score Text: Position (20, -20), Text = "Score: 0"
   - Coins Text: Position (20, -60), Text = "Coins: 0"
   - GameOver Panel: Full screen with semi-transparent background
   - GameOver Text: Centered, displays final score
3. Add Button (Restart):
   - Anchor: Center bottom
   - Text: "Restart"
   - On Click: Call GameManager.RestartGame()

### 9. GameManager Setup
1. Create empty GameObject named "GameManager"
2. Add Component > GameManager Script
3. Drag Score Text into "Score Text" field
4. Drag Coins Text into "Coins Text" field
5. Drag GameOver Panel into "Game Over Text" field
6. Drag Restart Button into "Restart Button" field

### 10. WorldGenerator Setup
1. Create empty GameObject named "WorldGenerator"
2. Add Component > WorldGenerator Script
3. Drag GroundTile Prefab into "Ground Tile Prefab" field
4. Drag Obstacle Prefab into "Obstacle Prefab" field
5. Drag Coin Prefab into "Coin Prefab" field
6. Adjust settings:
   - Tile Length: 10
   - Spawn Distance: 100
   - Obstacle Density: 0.3
   - Coin Density: 0.4

### 11. CameraController Setup
1. Select Main Camera
2. Add Component > CameraController Script
3. Drag Player into "Player Transform" field
4. Adjust offset: (0, 5, -10)
5. Smooth Speed: 5

### 12. AudioManager Setup
1. Create empty GameObject named "AudioManager"
2. Add Component > Audio Source
3. Add Component > AudioManager Script
4. Import audio clips and assign:
   - Coin Sound
   - Jump Sound
   - Crash Sound
   - Background Music

## Physics Settings

Edit > Project Settings > Physics
- Gravity: (0, -9.81, 0)
- Default Material: Create a physics material with:
  - Drag: 0
  - Angular Drag: 0.05
  - Friction: 0.4

## Build Settings

1. File > Build Settings
2. Add current scene to Scenes In Build
3. Platform: PC, Mac & Linux Standalone (or Android/iOS for mobile)
4. Player Settings:
   - Product Name: "Subway Surfers"
   - Default Icon
   - Resolution: 1920x1080

## Controls

- **A / Left Arrow**: Move Left
- **D / Right Arrow**: Move Right
- **W / Space / Up Arrow**: Jump
- **S / Down Arrow**: Slide

## Tips for Enhancement

1. Add particle effects on coin collection
2. Add animations for player jump/slide
3. Implement power-ups (shield, speed boost)
4. Add leaderboard system
5. Create multiple levels/themes
6. Add sound effects for crashes
7. Implement daily challenges
8. Create shop system for skins
