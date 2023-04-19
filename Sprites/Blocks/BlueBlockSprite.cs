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
    internal class BlueBlockSprite : AbstractSprite
    {
        public BlueBlockSprite() : base(1)
        {
            // These two items tell us everything about what sprite we are going to draw
            source = new Rectangle(64, 0, 32, 32);
            spritesheet = GameMain.Instance.BlockSpritesheet;
        }
    }
}
