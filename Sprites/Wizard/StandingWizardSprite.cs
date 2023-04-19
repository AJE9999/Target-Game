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
    internal class StandingWizardSprite : AbstractSprite
    {
        public StandingWizardSprite() : base(2)
        {
            // These two items tell us everything about what sprite we are going to draw
            if (GameMain.Instance.characterSelection == 0)
            {
                source = new Rectangle(0, 0, 17, 32);
                spritesheet = GameMain.Instance.WizardSpritesheet;
            }
            else if (GameMain.Instance.characterSelection == 1)
            {
                source = new Rectangle(39, 102, 18, 25);
                spritesheet = GameMain.Instance.NekoSpritesheet;
            }
        }
    }
}
