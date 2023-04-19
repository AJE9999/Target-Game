using Microsoft.Xna.Framework.Input;

namespace Untitled_Project
{
    internal static class MyKeyboard
    {
        private static KeyboardState keyboardState1 = new();
        private static KeyboardState keyboardState2 = new();
        
        public static void Update()
        {
            keyboardState1 = keyboardState2;
            keyboardState2 = Keyboard.GetState();
        }

        public static KeyboardState GetState()
        {
            return keyboardState2;
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyboardState2.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return keyboardState2.IsKeyUp(key);
        }

        public static bool WasKeyPressed(Keys key)
        {
            return !keyboardState1.IsKeyDown(key) && keyboardState2.IsKeyDown(key);
        }

        public static bool WasKeyReleased(Keys key)
        {
            return keyboardState1.IsKeyDown(key) && !keyboardState2.IsKeyDown(key);
        }

        public static bool WasAnyKeyPressed()
        {
            return keyboardState2.GetPressedKeyCount() > keyboardState1.GetPressedKeyCount();
        }

        public static bool WasEnterPressed()
        {
            return !keyboardState1.IsKeyDown(Keys.Enter) && keyboardState2.IsKeyDown(Keys.Enter);
        }
    }
}
