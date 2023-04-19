using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.Sprites.Misc
{
    internal class TargetSprite : AbstractSprite
    {
        public TargetSprite() : base(2)
        {
            // These two items tell us everything about what sprite we are going to draw
            source = new Rectangle(0, 0, 16, 16);
            spritesheet = GameMain.Instance.TargetSpritesheet;
        }
    }
}
