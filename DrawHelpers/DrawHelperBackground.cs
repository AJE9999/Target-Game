using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.DrawHelpers
{
    public static class DrawHelperBackground
    {
        private static int width;
        private static int height;
        private static SpriteBatch spriteBatch;

        public static void Initialize(int x, int y)
        {
            width = x;
            height = y;
            spriteBatch = GameMain.Instance.spriteBatch;
        }

        public static void DrawBackground(Texture2D texture)
        {
            int textureWidth = texture.Width; 
            int textureHeight = texture.Height;

            for (int i = 0; i < width; i += textureWidth)
            {
                for(int j = 0; j < height; j += textureHeight)
                {
                    spriteBatch.Draw(texture, new Rectangle(i, j, textureWidth, textureHeight), Color.White);
                }
            }
        }
    }
}
