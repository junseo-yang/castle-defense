using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CastleDefense
{
	static class Input
	{
		private static KeyboardState keyboardState, lastKeyboardState;
		private static MouseState mouseState, lastMouseState;
		private static GamePadState gamepadState, lastGamepadState;

		public static Vector2 MousePosition { get { return new Vector2(mouseState.X, mouseState.Y); } }

		public static void Update()
		{
			lastKeyboardState = keyboardState;
			lastMouseState = mouseState;
			lastGamepadState = gamepadState;

			keyboardState = Keyboard.GetState();
			mouseState = Mouse.GetState();
			gamepadState = GamePad.GetState(PlayerIndex.One);
		}

		// Checks if a key was just pressed down
		public static bool WasKeyPressed(Keys key)
		{
			return lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
		}

		public static bool WasButtonPressed(Buttons button)
		{
			return lastGamepadState.IsButtonUp(button) && gamepadState.IsButtonDown(button);
		}

		public static Vector2 GetAimDirection()
		{
			return GetMouseAimDirection();
		}

		private static Vector2 GetMouseAimDirection()
		{
			Vector2 direction = MousePosition - new Vector2(900, 395);

			return Vector2.Normalize(direction);
		}
	}    
}
