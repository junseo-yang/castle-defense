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

		public static Vector2 GetMovementDirection()
		{

			Vector2 direction = gamepadState.ThumbSticks.Left;
			direction.Y *= -1;  // invert the y-axis

			if (keyboardState.IsKeyDown(Keys.A))
				direction.X -= 1;
			if (keyboardState.IsKeyDown(Keys.D))
				direction.X += 1;
			if (keyboardState.IsKeyDown(Keys.W))
				direction.Y -= 1;
			if (keyboardState.IsKeyDown(Keys.S))
				direction.Y += 1;

			// Clamp the length of the vector to a maximum of 1.
			if (direction.LengthSquared() > 1)
				direction.Normalize();

			return direction;
		}

		public static Vector2 GetAimDirection()
		{
			return GetMouseAimDirection();
		}

		private static Vector2 GetMouseAimDirection()
		{
			Vector2 direction = MousePosition - new Vector2(900, 395);

			Debug.WriteLine($"x: {MousePosition.X} y: {MousePosition.Y}");

			return Vector2.Normalize(direction);

			//if (direction == Vector2.Zero)
			//	return Vector2.Zero;
			//else
			//	return Vector2.Normalize(direction);
		}

		public static bool WasBombButtonPressed()
		{
			return WasButtonPressed(Buttons.LeftTrigger) || WasButtonPressed(Buttons.RightTrigger) || WasKeyPressed(Keys.Space);
		}
	}    
}
