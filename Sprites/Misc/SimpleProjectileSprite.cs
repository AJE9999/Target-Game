using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Untitled_Project.Sprites.Misc
{
    internal class SimpleProjectileSprite : AbstractSprite
    {
        public SimpleProjectileSprite() : base(2)
        {
            // These two items tell us everything about what sprite we are going to draw
            source = new Rectangle(0, 0, 16, 16);
            spritesheet = GameMain.Instance.SimpleProjectileSpritesheet;
        }
    }
}