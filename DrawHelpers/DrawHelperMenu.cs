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
    public static class DrawHelperMenu
    {
        private static int xCenter;
        private static int yCenter;
        private static int width;
        private static int height;
        private static SpriteBatch spriteBatch;

        public static void Initialize(int x, int y)
        {
            width = x;
            height = y;
            xCenter = width / 2;
            yCenter = height / 2;
            spriteBatch = GameMain.Instance.spriteBatch;
        }

        public static void DrawStringCentered(SpriteFont font, string s, Color color)
        {
            spriteBatch.DrawString(font, s, new Vector2(xCenter, yCenter) - (font.MeasureString(s) / 2), color);
        }

        public static void DrawStringVerticallyCentered(SpriteFont font, string s, float x, Color color)
        {
            Debug.Assert(0 <= x && x <= 1, "x must be between 0 and 1, inclusive");
            spriteBatch.DrawString(font, s, new Vector2(x * width, yCenter) - (font.MeasureString(s) / 2), color);
        }

        public static void DrawStringHorizontallyCentered(SpriteFont font, string s, float y, Color color)
        {
            Debug.Assert(0 <= y && y <= 1, "y must be between 0 and 1, inclusive");
            spriteBatch.DrawString(font, s, new Vector2(xCenter, y * height) - (font.MeasureString(s) / 2), color);
        }

        public static void DrawCursor(Texture2D sprite, float startOfMenu, float menuSpacing, int cursorLocation, SpriteFont font, string displayString)
        {
            spriteBatch.Draw(
                sprite,
                new Rectangle(
                    xCenter - (int)((font.MeasureString(displayString).X / 2)) - ( 3 * sprite.Width / 2),
                    (int)((startOfMenu * height) + (cursorLocation * menuSpacing * height) - (sprite.Height / 2)),
                    sprite.Width,
                    sprite.Height),
                Color.Red);
            spriteBatch.Draw(
                sprite,
                new Rectangle(
                    xCenter + (int)((font.MeasureString(displayString).X / 2)) + (sprite.Width / 2),
                    (int)((startOfMenu * height) + (cursorLocation * menuSpacing * height) - (sprite.Height / 2)),
                    sprite.Width,
                    sprite.Height),
                null,
                Color.Red,
                0,
                new Vector2(),
                SpriteEffects.FlipHorizontally,
                0);
        }
    }
}
