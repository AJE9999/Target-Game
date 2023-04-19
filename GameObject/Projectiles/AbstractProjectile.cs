using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.GameObject.Enemy;
using Untitled_Project.Sprites.Misc;

namespace Untitled_Project.GameObject.Misc
{
    internal abstract class AbstractProjectile : AbstractGameObject
    {
        public bool bounce;
        public int speed;
        public float speedX;
        public float speedY;
        public int lifetime;
        // 0 is for player, 1 is for enemy
        public int origin;

        public AbstractProjectile(int x, int y, int origin) : base(x,y)
        {
            bounce = false;
            speed = 10;
            lifetime = 150;
            this.origin = origin;
        }

        public override void Update()
        {
            if(lifetime-- == 0)
            {
                this.Die();
            }
        }

        //Right now, x tells information about the direction of the collision. 
        //0 means side to side, 1 means top to bottom
        public virtual void OnHit(bool x)
        {
            //if it bounces, then let it bounce
            if (bounce)
            {
                if (x)
                    speedX *= -1;
                else
                    speedY *= -1;
            }
            else 
                //if it doesn't bounce, then it hit something and it should die
                Die();
        }

        public virtual void Die()
        {
            //Do the projectile death animation in subclass
            LevelGameState.KillProjectile(this);
        }
    }
}
