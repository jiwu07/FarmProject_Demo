# FarmProject_Demo

## 🌍 English (Scroll down for 中文版)

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

All 3D models, environments, and character assets are sourced from the Unity Asset Store and are clearly labeled in the project directory. These assets were used solely for prototyping purposes; all core logic, interaction systems, and custom scripts were independently developed.



# FarmProject_Demo
## 🇨🇳 中文说明

一个基于 Unity 3D 的固定视角农场游戏 Demo，支持 Android 平台导出。该项目展示了角色控制、任务系统、种植系统、建筑放置系统、角色技能与切换等核心玩法与架构设计。

## 🎮 游戏玩法简介

- 玩家点击地面移动并进行交互（支持鼠标或触屏）。
- 玩家在农场中自由活动，可接取任务、种植作物、浇水、收获并出售以赚取金币。
- 支持角色切换，不同角色拥有不同技能。
- 地图中可交互的“胡萝卜建筑”提供抽奖玩法。
- 通过任务面板接取任务，完成后提交并获得奖励。
- 使用背包管理物品，可切换至建筑模式进行建筑放置与拾取。
- 植物分阶段成长，玩家需合理等待、浇水、收获。
- 头顶提示系统（Notification）会反馈如金币不足、技能不匹配等信息。

## 🎭 角色与技能示例

- `Gardener`: 可种植植物并进行浇水。
- `Harvester`: 可收割植物并进行出售。

## ⚙ 技术实现

- 使用 Unity 新输入系统（Input System）支持点击与触控识别。
- 使用 `Animator Controller` 实现 Idle、走路等基础动画。
- 所有交互元素均通过脚本控制，具备良好的扩展性。
- UI 包括任务系统、背包系统、金币提示、交互引导等。
- 建筑系统使用自定义 GridManager 控制，每个地块支持放置/拾取操作。
- 使用 `ScriptableObject` 管理任务、角色、土地与植物，提高数据可扩展性。
- 使用 NavMesh 处理任务角色的自动寻路。

## 📱 适配情况

- 主要面向 Android 平台，使用新输入系统同样兼容 PC 鼠标点击。
- 当前版本暂不支持数据存档功能。

## 📺 项目演示

> 示例截图：开始界面 & 游戏主界面  
（见上面）

## 🔮 后续开发计划

- 增加 NPC 对话与任务互动
- 扩展角色技能，加入技能冷却与自动操作
- 丰富植物种类与动画表现
- 增加建筑系统支持更多类型
- 增加存档与读取功能
- 加入音效与背景音乐（考虑 FMOD）

## 🤝 特别说明

本项目为个人独立开发，旨在展示在 Unity 游戏玩法编程、模块化系统架构设计及 UI/UX 集成方面的能力。

项目中所使用的三维模型、场景和角色资源均来自 Unity Asset Store，已在项目目录中清晰标注，仅用于原型展示目的。项目的核心逻辑、交互系统及自定义脚本均由本人独立开发完成。

