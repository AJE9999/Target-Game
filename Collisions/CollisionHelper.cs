using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Sprites;

namespace Untitled_Project.Collisions
{
    public static class CollisionHelper
    {
        public static Rectangle Hitbox(int x, int y, AbstractSprite sprite)
        {
            return new Rectangle(x, y, sprite.source.Width * sprite.scale, sprite.source.Height * sprite.scale);
        }
    }
}
