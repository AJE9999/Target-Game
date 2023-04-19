using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.DrawHelpers;

namespace Untitled_Project.Sprites.Blocks
{
    internal class WalkingLeftWizardSprite : AbstractSprite
    {
        int animationCycleLength = 144;
        int frame = 0;
        int numberOfFrames = 12;
        int x = 0;
        int neko = 15;
        public WalkingLeftWizardSprite() : base(2)
        {
            // These two items tell us everything about what sprite we are going to draw
            if (GameMain.Instance.characterSelection == 0)
            {
                source = new Rectangle(17, 0, 17, 32);
                spritesheet = GameMain.Instance.WizardSpritesheet;
            }
            else if (GameMain.Instance.characterSelection == 1)
            {
                source = new Rectangle(40, 38, 18, 25);
                spritesheet = GameMain.Instance.NekoSpritesheet;
            }
        }

        public override void Update()
        {
            

            if (GameMain.Instance.characterSelection == 0)
            {
                source = new Rectangle(17 * (1 + (frame / (animationCycleLength / numberOfFrames))), 0, 17, 32);
                if (frame++ == animationCycleLength)
                {
                    frame = 0;
                }
            }
            else if (GameMain.Instance.characterSelection == 1)
            {
                x++;
                if (x == neko * 4)
                {
                    source = new Rectangle(40, 38, 18, 25);
                    x = 0;
                }
                else if (x >= neko * 3)
                    source = new Rectangle(8, 39, 18, 25);
                else if (x >= neko * 2)
                    source = new Rectangle(40, 38, 18, 25);
                else if (x >= neko)
                    source = new Rectangle(72, 39, 18, 25);

            }
        }

        public override void Draw(int x, int y)
        {
            if (GameMain.Instance.characterSelection == 0)
            {
                GameMain.Instance.spriteBatch.Draw(
                spritesheet,
                new Rectangle(x, y, source.Width * scale, source.Height * scale),
                source,
                Color.White,
                0.0f,
                new Vector2(0, 0),
                SpriteEffects.FlipHorizontally,
                1
            );
            }
            else if (GameMain.Instance.characterSelection == 1)
            {
                GameMain.Instance.spriteBatch.Draw(
                spritesheet,
                new Rectangle(x, y, source.Width * scale, source.Height * scale),
                source,
                Color.White);
            }
        }
    }
}
