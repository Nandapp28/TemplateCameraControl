# TemplateCameraControl

A Unity template project featuring a comprehensive third-person camera control system with multiple camera modes, player movement, and animation integration.

## 🎮 Features

### Camera System
- **Multiple Camera Modes**: Switch between Basic, Combat, and Top-down camera perspectives
- **Smooth Camera Transitions**: Seamless switching between different camera styles
- **Third-Person Controls**: Professional third-person camera implementation
- **Combat Focus**: Dedicated combat camera mode for enhanced gameplay

### Player Movement
- **Responsive Movement**: WASD movement with customizable speed settings
- **Sprint System**: Hold Left Shift to sprint with speed multiplier
- **Jump Mechanics**: Space bar jumping with cooldown and air control
- **Ground Detection**: Reliable ground checking with LayerMask support
- **Physics-Based**: Uses Rigidbody for realistic movement physics

### Animation Integration
- **State-Based Animation**: Idle, Walk, Run, and Jump animation states
- **Smooth Transitions**: Automatic animation blending based on player actions
- **Modular Design**: Separate animation controller for easy customization

## 📁 Project Structure
Assets/
├── FBX/                    # 3D models and animator controllers
├── Material/               # Materials and textures
├── Scenes/                 # Unity scenes
└── Scripts/
├── AnimationController.cs    # Handles character animations
├── CameraController.cs       # Third-person camera system
└── PlayerMovement.cs         # Player movement and physics


## 🛠️ Requirements

- **Unity Version**: 2022.3 LTS or later
- **Required Packages**:
  - Cinemachine (2.10.4)
  - TextMeshPro (3.0.7)
  - Timeline (1.7.7)
  - Visual Scripting (1.9.4)

## 🚀 Setup Instructions

### Step 1: Install Unity
1. Download and install **Unity Hub** from [unity.com](https://unity.com/download)
2. Install **Unity 2022.3 LTS** through Unity Hub:
   - Open Unity Hub
   - Go to "Installs" tab
   - Click "Install Editor"
   - Select "2022.3 LTS" version
   - Choose modules (recommended: Windows/Mac Build Support)

### Step 2: Open the Project
1. Clone or download this repository
2. Open Unity Hub
3. Click "Open" or "Add project from disk"
4. Navigate to the `TemplateCameraControl` folder
5. Select the folder and click "Open"

### Step 3: Project Setup
1. Unity will automatically import all assets and packages
2. Wait for the import process to complete
3. If prompted about Unity version differences, choose "Continue"

## ▶️ Running the Project

### Method 1: Play in Editor
1. Open Unity with the project loaded
2. In the **Project** window, navigate to `Assets/Scenes/`
3. Double-click on the main scene to open it
4. Click the **Play** button (▶️) at the top of the Unity Editor
5. The game will start in the Scene view/Game view

### Method 2: Build and Run
1. Go to **File** → **Build Settings**
2. Click **Add Open Scenes** to add current scene
3. Select your target platform (PC, Mac, Linux)
4. Click **Build and Run**
5. Choose a location to save the build
6. Unity will build and automatically run the executable

## 🎮 Controls

| Input | Action |
|-------|--------|
| **WASD** | Move player |
| **Mouse** | Look around (camera control) |
| **Space** | Jump |
| **Left Shift** | Sprint (hold) |
| **C** | Switch camera modes |
| **Escape** | Unlock cursor |

## 🔧 Customization

### Camera Settings
Modify camera behavior in the `ThirdPersonCam` script:
- `speed`: Camera follow speed
- Camera mode switching logic
- Combat center positioning

### Movement Settings
Adjust player movement in the `PlayerMovement` script:
- `moveSpeed`: Base movement speed
- `jumpForce`: Jump strength
- `groundDrag`: Ground friction
- `airMultiplier`: Air control factor

### Animation Settings
Customize animations in the `AnimationController` script:
- Animation state transitions
- Blend tree parameters
- Animation triggers

## 🐛 Troubleshooting

### Common Issues

**Camera not following player:**
- Ensure player Transform is assigned in CameraController
- Check if orientation Transform is properly set

**Player not moving:**
- Verify Rigidbody component is attached to player
- Check if ground layer mask is correctly configured

**Animations not playing:**
- Ensure Animator component has the correct controller assigned
- Verify animation parameters match script references

**Build errors:**
- Check Unity version compatibility
- Ensure all required packages are installed
- Verify scene is added to Build Settings

## 📝 License

This project is licensed under the terms specified in the LICENSE.md file.

## 🤝 Contributing

Feel free to fork this project and submit pull requests for improvements or bug fixes.

---

**Happy Game Development! 🎮**