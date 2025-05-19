# Orangutan Room

## Overview
An immersive VR safe space for users to speak freely to a massive, disinterested orangutan eating a banana. The orangutan displays randomized idle behaviors (banana eating, scratching, chewing, farting, yawning, shifting) while ignoring user input. Sessions record user audio for later review.

## Features
- VR scene: simple room environment with ambient jungle sounds  
- Animated orangutan: rigged model with idle animations (now including yawning and shifting) and synced audio  
- Voice capture: record user microphone input without analysis  
- Behavior scheduler: random idle actions on fixed intervals or voice-triggered timers  
- Session management: start/end controls, configurable session length  
- Local storage: save session audio files and metadata  
- Performance: baked lighting, occlusion culling, target 90 FPS on headset  

## Prerequisites
- Unity 2021.3 LTS or later  
- XR Plugin Management package  
- OpenXR or platform-specific XR provider  
- .NET Framework 4.x compatibility  

## Installation
1. Clone repository:  
```bash
git clone https://github.com/GrahamPaasch/orangutan_room.git
```

2. Open project in Unity Editor.
3. Install required packages via Package Manager: XR Plugin Management, Input System.
4. Import rigged orangutan model and AudioClips into Assets/Models and Assets/Audio.

## Configuration

* Assign rigged model and AudioClips to OrangutanBehaviour component.
* Configure XR settings under Project Settings > XR Plugin Management.
* Set microphone permissions for target platform.

## Usage

1. Load **SampleScene** in Unity.
2. Drag **OrangutanBehaviour**, **SessionRecorder**, and **SessionController** onto the orangutan GameObject.
3. Attach **OrangutanRoomInitializer** to an empty GameObject and assign the orangutan prefab and player rig.
4. Enter Play Mode or build to headset (File > Build Settings).
5. Use UI controls to start and stop sessions.
6. Retrieve recorded audio files from `Application.persistentDataPath`.

## Deployment (Oculus Quest 1)

1. Install **Android Build Support** in Unity Hub.
2. Put your Quest 1 into **Developer Mode** and connect it via USB.
3. Open **File > Build Settings** and switch the platform to **Android**.
4. Under **Project Settings > XR Plugin Management**, enable **Oculus** (or OpenXR).
5. Click **Build** to generate an APK file.
6. Use `adb install <APK>` or Oculus Developer Hub to sideload the build.
7. Launch the app on the headset and confirm it runs without console errors.

## Project Structure

```
/Assets
  /Scenes
    SampleScene.unity
  /Scripts
    ActionIntervalSlider.cs
    OrangutanBehaviour.cs
    SessionRecorder.cs
    SessionController.cs
    OrangutanRoomInitializer.cs
  /Models
    Orangutan.fbx
  /Audio
    FartSound.wav
    JungleAmbience.wav
    Yawn.wav
    Shift.wav
README.md
AGENTS.md
```

## Development Workflow

* Author prompts in AGENTS.md for Codex integration.
* Generate or refine scripts via CodexClient integration.
* Test behaviors in Editor, fix compile errors.
* Profile performance on target headset.
* Commit working code to source control.

## Roadmap

* Add additional idle animations (yawning, shifting) - done
* Implement adjustable timers via UI - done
* Integrate spatial audio for orangutan sounds
* Export session metrics (duration, audio length)
