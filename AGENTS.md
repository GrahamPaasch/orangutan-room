# AGENTS.md

## Project Overview
- orangutan_room: VR safe‐space where user speaks to a disinterested orangutan.
- Root contains Scenes, Scripts, Models, Audio, README.md, AGENTS.md.

## Code Style
- Follow Unity C# standards: PascalCase for classes/methods, camelCase for private fields.
- Remove unused `using` directives.
- Place braces on new lines.
- Adhere to configured `.editorconfig`.

## Directory Structure
- `/Assets/Scenes`: Unity scenes (`SampleScene.unity`).
- `/Assets/Scripts`: C# MonoBehaviours (`OrangutanBehaviour.cs`, `SessionRecorder.cs`).
- `/Assets/Models`: FBX models and prefabs (`Orangutan.fbx`).
- `/Assets/Audio`: AudioClips (`FartSound.wav`, `JungleAmbience.wav`).

## Testing & Validation
- Enter Play Mode; ensure no console errors or warnings.
- Verify Animator transitions for orangutan idle states.
- Check microphone recording triggers and file output (`persistentDataPath/*.wav`).

## Build & Deployment
- Configure XR Plugin Management for target platform (OpenXR, Oculus).
- Build via File > Build Settings; target Android (Quest) or PC VR.
- Confirm application runs at ≥ 90 FPS on device.

## Session Recording
- `SessionRecorder` must save audio with filename format `YYYYMMDD_HHMMSS.wav`.
- Store recordings in `Application.persistentDataPath`.

## Commit & PR Guidelines
- Commit prefixes: `[Add]`, `[Fix]`, `[Feat]`, `[Refactor]`.
- Commit title: `<Prefix> Brief description`.
- PR description sections:
  1. **Summary**: one‐line overview.
  2. **Testing Steps**: list of steps performed.
