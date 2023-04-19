using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    internal class PauseGameState : IGameState
    {
        private int cursorLocation = 0;
        private float startOfMenuList = 0.3f;
        private float menuSpacing = 0.1f;
        private AbstractSprite menuArrowSprite = new MenuArrowSprite();

        public static string[] displayStrings = new string[]
        {
            "Resume Game", "Settings", "Return to Main Menu", "Exit Game"
        };

        public void Draw()
        {
            GameMain.Instance.GraphicsDevice.Clear(Color.Black);

            DrawHelperMenu.DrawStringHorizontallyCentered(GameMain.Instance.spriteFont, "GAME PAUSED", 0.1f, Color.White);

            // draw settings options
            for ( int i = 0; i < displayStrings.Count(); i++)
            {
                DrawHelperMenu.DrawStringHorizontallyCentered(GameMain.Instance.spriteFont, displayStrings[i], startOfMenuList + (i * menuSpacing), Color.White);
            }

            // CURSOR
            DrawHelperMenu.DrawCursor(menuArrowSprite.spritesheet, startOfMenuList, menuSpacing, cursorLocation, GameMain.Instance.spriteFont, displayStrings[cursorLocation]);
        }

        public int Update()
        {
            //CURSOR MOVEMENT
            if (cursorLocation < displayStrings.Count() - 1 && MyKeyboard.WasKeyPressed(Keys.Down))
                cursorLocation++;
            else if (cursorLocation > 0 && MyKeyboard.WasKeyPressed(Keys.Up))
                cursorLocation--;

            return cursorLocation;
        }
    }
}
