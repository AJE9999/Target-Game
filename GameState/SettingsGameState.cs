using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.DrawHelpers;
using Untitled_Project.Sprites;
using Untitled_Project.Sprites.Blocks;
using Untitled_Project.Sprites.Misc;

namespace Untitled_Project
{
    internal class SettingsGameState : IGameState
    {
        private int cursorLocation = 0;
        private float startOfMenuList = 0.3f;
        private float menuSpacing = 0.1f;
        private AbstractSprite menuArrowSprite = new MenuArrowSprite();
        private SpriteFont spriteFont = GameMain.Instance.spriteFont;

        public static string[] displayStrings = new string[]
        {
                "Resolution: " + GameMain.Instance.graphics.PreferredBackBufferWidth + " x " + GameMain.Instance.graphics.PreferredBackBufferHeight, "Apply", "Exit Settings"
        };

        private static string[] resolutionOptions = new string[]
        {
            "800 x 600", "1024 x 768", "1280 x 960"
        };

        int selectedResolution = Array.IndexOf(resolutionOptions, GameMain.Instance.graphics.PreferredBackBufferWidth + " x " + GameMain.Instance.graphics.PreferredBackBufferHeight);

        public void Draw()
        {
            GameMain.Instance.GraphicsDevice.Clear(Color.Black);

            // draw settings options
            for (int i = 0; i < displayStrings.Length; i++)
            {
                DrawHelperMenu.DrawStringHorizontallyCentered(spriteFont, displayStrings[i], startOfMenuList + (i * menuSpacing), Color.White);
            }

            // CURSOR
            DrawHelperMenu.DrawCursor(menuArrowSprite.spritesheet, startOfMenuList, menuSpacing, cursorLocation, spriteFont, displayStrings[cursorLocation]);
        }

        public int Update()
        {
            //CURSOR MOVEMENT
            if (cursorLocation < displayStrings.Count() - 1 && MyKeyboard.WasKeyPressed(Keys.Down))
                cursorLocation++;
            else if (cursorLocation > 0 && MyKeyboard.WasKeyPressed(Keys.Up))
                cursorLocation--;
            else if (cursorLocation == 0 && selectedResolution > 0 && MyKeyboard.WasKeyPressed(Keys.Left))
                selectedResolution--;
            else if (cursorLocation == 0 && selectedResolution < resolutionOptions.Count() - 1 && MyKeyboard.WasKeyPressed(Keys.Right))
                selectedResolution++;
            else if (displayStrings[cursorLocation].Equals("Apply") && MyKeyboard.WasKeyPressed(Keys.Enter))
                UpdateSettings();

            UpdateDisplayStrings();

            return cursorLocation;
        }

        private void UpdateDisplayStrings()
        {
            displayStrings[0] = "Resolution: " + resolutionOptions[selectedResolution];
        }

        private void UpdateSettings()
        {
            UpdateResolution();
        }

        private void UpdateResolution()
        {
            string[] dim = resolutionOptions[selectedResolution].Split(" x ");
            int newWidth = int.Parse(dim[0]);
            int newHeight = int.Parse(dim[1]);
            GameMain.UpdateResolution(newWidth, newHeight);
        }
    }
}
