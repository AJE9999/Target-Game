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
    internal class WalkingRightWizardSprite : AbstractSprite
    {
        int animationCycleLength = 144;
        int frame = 0;
        int numberOfFrames = 12;
        int x = 0;
        int neko = 15;
        public WalkingRightWizardSprite() : base(2)
        {
            // These two items tell us everything about what sprite we are going to draw
            if (GameMain.Instance.characterSelection == 0)
            {
                source = new Rectangle(17, 0, 17, 32);
                spritesheet = GameMain.Instance.WizardSpritesheet;
            }
            else if (GameMain.Instance.characterSelection == 1)
            {
                source = new Rectangle(39, 70, 18, 25);
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
                    source = new Rectangle(39, 70, 18, 25);
                    x = 0;
                }
                else if (x >= neko * 3)
                    source = new Rectangle(5, 71, 20, 25);
                else if (x >= neko * 2)
                    source = new Rectangle(39, 70, 18, 25);
                else if (x >= neko)
                    source = new Rectangle(72, 71, 17, 25);

            }
        }
    }
}
