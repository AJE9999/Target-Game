using Microsoft.Xna.Framework;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Collisions;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.GameObject.Enemy;
using Untitled_Project.GameObject.Misc;
using Untitled_Project.Sprites.Misc;

namespace Untitled_Project.GameObject.Projectiles
{
    internal class SimpleProjectile : AbstractProjectile
    {
        public SimpleProjectile(int x, int y, Vector2 dir) : base(x, y, 0)
        {
            sprite = new SimpleProjectileSprite();
            bounce = true;

            dir.Normalize();
            speed = 5;
            speedX = dir.X * speed;
            speedY = dir.Y * speed;

            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }

        public override void Update()
        {
            base.Update();

            x -= (int)speedX;
            y -= (int)speedY;
            sprite.Update();

            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }

        public override void OnHit(bool x)
        {
            base.OnHit(x);
        }

        public override void Die()
        {
            base.Die();
        }
    }
}
