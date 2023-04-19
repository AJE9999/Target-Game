using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.Sprites.Misc
{
    internal class MenuArrowSprite : AbstractSprite
    {
        public MenuArrowSprite() : base(1)
        {
            // These two items tell us everything about what sprite we are going to draw
            source = new Rectangle(0, 0, 32, 32);
            spritesheet = GameMain.Instance.MenuArrowSpritesheet;
        }
    }
}
