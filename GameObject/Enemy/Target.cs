using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Collisions;
using Untitled_Project.Sprites.Misc;

namespace Untitled_Project.GameObject.Enemy
{
    internal class Target : AbstractEnemy
    {
        public Target(int x, int y) : base(x,y)
        {
            sprite = new TargetSprite();
            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }

        public override void Draw()
        {
            sprite.Draw(x, y);
        }
    }
}
