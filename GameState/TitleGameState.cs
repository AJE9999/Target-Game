using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.DrawHelpers;

namespace Untitled_Project
{
    internal class TitleGameState : IGameState
    {
        private int frame = 0;
        private int colorChangeRate = 60;
        private SpriteFont font = GameMain.Instance.spriteFont;
        private Color textColor = Color.Black;
        public void Draw()
        {
            GameMain.Instance.GraphicsDevice.Clear(Color.Red);

            textColor = frame >= 0 ? Color.Black : Color.White;

            DrawHelperMenu.DrawStringCentered(font, "TITLE SCREEN", textColor);
        }

        public int Update()
        {
            frame++;
            if (frame == colorChangeRate)
            {
                frame = -colorChangeRate;
            }

            return 0;
        }
    }
}
