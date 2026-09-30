# Subway Surfers Game - Complete Edition

A fully functional Subway Surfers-style endless runner game built with Unity.

## Features

✅ **Three-lane movement system** - Smooth lane switching  
✅ **Jump and Slide mechanics** - Avoid obstacles dynamically  
✅ **Obstacle system** - Randomly generated obstacles  
✅ **Coin collection** - Earn points and collect coins  
✅ **Score system** - Progressive scoring as you advance  
✅ **Progressive difficulty** - Game speeds up over time  
✅ **UI System** - Score, coins, and game over screens  
✅ **Camera follow system** - Dynamic third-person camera  
✅ **Audio management** - Background music and sound effects  
✅ **Physics-based movement** - Realistic jump and fall mechanics  

## Project Structure

```
Assets/
├── Scripts/
│   ├── PlayerController.cs       - Player movement and controls
│   ├── GameManager.cs            - Game logic and UI management
│   ├── WorldGenerator.cs         - Level and obstacle generation
│   ├── Obstacle.cs               - Obstacle behavior
│   ├── Coin.cs                   - Coin behavior and collection
│   ├── CameraController.cs       - Camera follow system
│   ├── SpeedIncreaser.cs         - Progressive difficulty
│   └── AudioManager.cs           - Sound management
├── Prefabs/
│   ├── GroundTile.prefab         - Repeating ground tiles
│   ├── Obstacle.prefab           - Obstacle objects
│   └── Coin.prefab               - Coin objects
├── Materials/
│   ├── PlayerMaterial.mat
│   ├── GroundMaterial.mat
│   ├── ObstacleMaterial.mat
│   └── CoinMaterial.mat
└── Audio/
    ├── coin.wav
    ├── jump.wav
    ├── crash.wav
    └── background_music.mp3
```

## How to Use

### Setup Instructions

1. **Create a new 3D scene in Unity**
2. **Follow the ProjectSettings.md guide** for detailed setup
3. **Create required tags and layers**
4. **Build the scene hierarchy** as described
5. **Import scripts** into Assets/Scripts folder
6. **Create prefabs** for ground, obstacles, and coins
7. **Configure UI** with Canvas and buttons
8. **Add audio clips** (optional)
9. **Press Play** and enjoy!

### Controls

| Action | Key |
|--------|-----|
| Move Left | A or Left Arrow |
| Move Right | D or Right Arrow |
| Jump | W or Space or Up Arrow |
| Slide | S or Down Arrow |
| Restart | Click Restart Button |

## Script Documentation

### PlayerController.cs
Handles all player movement, input, and collision detection.
- **Key Methods**: `HandleInput()`, `HandleMovement()`, `Jump()`, `StartSlide()`
- **Physics**: Uses Rigidbody for realistic jumping

### GameManager.cs
Manages game state, scoring, and UI updates.
- **Key Methods**: `AddCoins()`, `GameOver()`, `RestartGame()`
- **UI Updates**: Handles score and coin display

### WorldGenerator.cs
Generates endless world with tiles, obstacles, and coins.
- **Key Methods**: `SpawnTile()`, `SpawnObstacle()`, `SpawnCoin()`
- **Optimization**: Despawns old tiles to save performance

### Obstacle.cs
Handles obstacle behavior and collision with player.
- **Detection**: Uses collision detection to end game
- **Slide Bypass**: Players can avoid obstacles by sliding

### Coin.cs
Handles coin rotation, movement, and collection logic.
- **Rotation**: Automatically spins for visual effect
- **Collection**: Awards points when collected by player

### CameraController.cs
Manages camera follow and positioning relative to player.
- **Smooth Following**: Uses lerp for smooth camera movement
- **Offset**: Maintains consistent camera distance and angle

### AudioManager.cs
Singleton audio system for background music and SFX.
- **Sound Types**: Coins, jumps, crashes, and background music
- **Persistent**: Audio continues across scene reloads

## Customization

### Adjust Difficulty
- Modify `obstacleDensity` in WorldGenerator (0-1)
- Modify `coinDensity` in WorldGenerator (0-1)
- Adjust `moveSpeed` in PlayerController

### Change Visuals
- Create new materials for player, ground, obstacles, coins
- Modify scale values in prefab setup
- Add particle effects to coins and obstacles

### Add Power-ups
- Create new prefabs for shield, speed boost, magnet
- Add logic to GameManager for power-up effects
- Extend PlayerController for power-up states

## Performance Tips

1. **Use Object Pooling** - Reuse obstacle/coin instances instead of creating new ones
2. **Optimize Materials** - Use simple shaders for better performance
3. **Limit Colliders** - Use simple box/sphere colliders when possible
4. **Audio Compression** - Compress audio files for smaller build size
5. **Mobile Optimization** - Reduce polygon count and use LOD meshes

## Known Issues & Solutions

**Issue**: Game lags when many obstacles spawn  
**Solution**: Implement object pooling (see Performance Tips)

**Issue**: Player falls through ground  
**Solution**: Ensure ground tiles have proper colliders and rigidbody settings

**Issue**: Coins not collecting  
**Solution**: Verify "Is Trigger" is enabled on coin colliders

## Future Enhancements

- [ ] Multiple characters with different abilities
- [ ] Power-up system (shield, speed boost, magnet)
- [ ] Leaderboard and high score system
- [ ] Different themes/environments
- [ ] Boss levels
- [ ] Daily challenges
- [ ] In-app purchases
- [ ] Mobile touch controls
- [ ] Game achievements/badges
- [ ] Particle effects and polish

## License

This project is open source and available for educational purposes.

## Support

For issues or questions:
1. Check ProjectSettings.md for setup guidance
2. Verify all tags and layers are created
3. Ensure all prefabs are properly configured
4. Check that scripts have all required component references assigned

---

**Happy Gaming!** 🎮
