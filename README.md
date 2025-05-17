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
2. Drag **OrangutanBehaviour** and **SessionRecorder** onto the orangutan GameObject.
3. Enter Play Mode or build to headset (File > Build Settings).
4. Use UI controls to start and stop sessions.
5. Retrieve recorded audio files from `Application.persistentDataPath`.

## Project Structure

```
/Assets
  /Scenes
    SampleScene.unity
  /Scripts
    OrangutanBehaviour.cs
    SessionRecorder.cs
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
* Implement adjustable timers via UI
* Integrate spatial audio for orangutan sounds
* Export session metrics (duration, audio length)
