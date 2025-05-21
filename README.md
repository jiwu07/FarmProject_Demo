# FarmProject_Demo

A fixed-perspective 3D farming game demo developed in Unity 2022.3.12f1, primarily built for Android with support for mouse input on PC. This project showcases core gameplay systems including player movement, task system, planting mechanics, inventory and building system, character switching, and clean architecture.

<img width="1360" alt="image" src="https://github.com/jiwu07/FarmProject_Demo/blob/main/Assets/StartScene.png">





## 🎮 Gameplay Overview

- Click or tap to move and interact with the world.
- Free exploration in your own farm with interactive elements.
- Task system: accept tasks from the task panel, track progress, and submit for rewards.
- Planting system: buy seeds, plant them on land tiles, water them, and harvest when mature.
- Gacha system: click on the carrot-shaped building to play a mini lottery game and win items or coins.
- Character system: switch between characters, each with unique abilities.
- Inventory system: access your backpack, place objects on land, or retrieve them into inventory via placement mode.
- Dynamic UI: coin counter, task notifications, and real-time feedback on user actions.
- Plant growth: progresses over time with visual cues (e.g., process bar, star icon when interaction is possible).
- Notification system: informs the player when they lack coins, appropriate abilities, etc.

## 👥 Character Abilities

- **Gardener**: Can plant and water crops.
- **Harvester / Employee**: Can harvest and sell crops.

## ⚙️ Technical Features

- Unity's **New Input System**: Handles both mouse and touch input for interactions.
- Uses **Animator Controller** for idle and walking animations.
- Modular UI system: task panel, bag, shop, coin tips, and context hints.
- Custom **Grid System** for object placement, implemented via a `GridManager`.
- Interactive cells highlight when hovered or selected.
- Data-driven design using **ScriptableObjects** for characters, tasks, land, and plant definitions.
- AI navigation (NavMesh) for pathfinding during task execution.

## 📱 Platform & Compatibility

- Designed for Android builds (APK supported).
- Also compatible with PC (mouse input supported).
- No save/load system implemented yet.

## 📷 Demo Preview
<img width="1360" alt="image" src="https://github.com/jiwu07/FarmProject_Demo/blob/main/Assets/ProjectScreenshotMailGameScene.png ">
<img width="1360" alt="image" src="https://github.com/jiwu07/FarmProject_Demo/blob/main/Assets/ProjectScreenshotMailGameScene2.png">


## 🚧 Future Roadmap

- Add NPCs for dialogue and quest interaction.
- Expand character abilities with cooldowns and AI automation.
- Introduce more land/plant types and animations.
- Extend building placement system.
- Add save/load support.
- Integrate audio using FMOD or Unity's audio system.

## 🙌 Notes

This project is a solo development initiative to demonstrate proficiency in Unity gameplay programming, modular system architecture, and UI/UX integration.
