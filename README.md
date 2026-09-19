# Memory Madness

A memory matching game developed in **Godot** using **C#**, following a Udemy course as a guided learning project.

The project recreates the classic memory game where the player flips cards and attempts to match pairs, while focusing on building an entire game using Godot's UI components.

## Features

- Classic card-matching gameplay
- Multiple levels with increasing difficulty
- Dynamically constructed game boards based on the selected level
- Card flipping and pair matching
- Main menu and game screens
- Level selection from the main menu
- UI-based game construction
- Game state and screen visibility management
- 2D game development using Godot
- C# scripting

## Technologies

- **Godot Engine**
- **C# / .NET**
- **Git / GitHub**

## Project Structure

```text
.
├── Assets/          # Game assets
├── Classes/         # Data classes
├── Globals/         # Global Singeltons
├── Resources/       # Godot resources
├── Scenes/          # Godot scenes
├── project.godot    # Godot project configuration
└── README.md
```

## Getting Started

### Prerequisites

- [Godot Engine](https://godotengine.org/) with C#/.NET support
- .NET SDK compatible with the version of Godot being used
- Git, if cloning the repository

### Running the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/apaquette/MemoryMadness.git
   ```

2. Open the project in the Godot editor.

3. Allow Godot to import and build the C# project if prompted.

4. Run the project using the **Play** button or the appropriate Godot run command.

## Controls

| Action | Input |
|---|---|
| Select / Flip Card | `Left Mouse Button` |

## Learning Context

This project was created while following the **Learn 2D Game Development: Godot 4 & C# from scratch** course on Udemy. It is primarily intended as a learning exercise for becoming familiar with:

- Building games using Godot's UI components
- Godot's scene and node architecture
- C# scripting within Godot
- Creating and managing UI controls
- Dynamically constructing game scenes
- Game state management
- Scene visibility management
- Passing level selections between scenes
- Structuring a small game project

The project uses a **Master scene** containing both the Main Scene and Game Scene. The Main Scene acts as the game's menu, while the Game Scene contains the gameplay. When a level is selected, the Game Scene is dynamically constructed based on the selected level, and visibility is toggled between the menu and gameplay interfaces.

## Credits

This project is based on the concepts and implementation taught in the **Learn 2D Game Development: Godot 4 & C# from scratch** Udemy course by Richard Allbert. It is an educational project based on the classic memory matching game.

## License

This project is provided for educational and personal learning purposes.
