using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Sprites.Misc;

namespace Untitled_Project.GameObject.Enemy
{
    public abstract class AbstractEnemy : AbstractGameObject
    {
        public int health;
        public AbstractEnemy(int x, int y) : base(x,y)
        {
        }

        public void Die()
        {
            //Do the enemy death animation in the subclass
            LevelGameState.KillEnemy(this);
        }
    }
}
