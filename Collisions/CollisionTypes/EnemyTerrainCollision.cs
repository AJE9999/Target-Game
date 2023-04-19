using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.GameObject;
using Untitled_Project.GameObject.Enemy;
using Untitled_Project.GameObject.Misc;

namespace Untitled_Project.Collisions.CollisionTypes
{
    internal class EnemyTerrainCollision : AbstractCollision
    {
        private AbstractGameObject terrain;
        private AbstractEnemy enemy;
        public EnemyTerrainCollision(AbstractGameObject terrain, AbstractEnemy enemy)
        {
            this.terrain = terrain;
            this.enemy = enemy;   
        }
        public override void ResolveCollision() {
            // TODO
        }
    }
}
