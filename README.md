# Desktop Goose Chat Mod

A mod for Desktop Goose that allows the goose to randomly open a chat window where you can have conversations with your annoying digital companion!

## Features
- 🪿 Goose randomly opens a chat window (just like memes and notes)
- 💬 Simple editor-style chat interface
- 🎭 Playful and annoying personality responses
- 🔧 Structured for easy future AI integration

## Installation

1. Build the project in Visual Studio (targeting .NET Framework 4.7.2)
2. Copy the compiled `ChatWithGooseMod.dll` to your Desktop Goose `Mods` folder
3. Copy `ModConfig.json` to the same `Mods` folder
4. Restart Desktop Goose

## Usage

The goose will randomly decide to open a chat window - just like it does with memes! When it appears:
- Type your message in the text box at the bottom
- Click "Send" or press Enter
- The goose will respond with its playful personality
- Close the window anytime (but the goose might open it again later!)

## Future Development

The code is structured to easily add AI integration - see comments in `GooseResponseHandler.cs` for integration points.