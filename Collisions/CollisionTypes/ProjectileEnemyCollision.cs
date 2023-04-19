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
    internal class ProjectileEnemyCollision : AbstractCollision
    {
        private AbstractEnemy enemy;
        private AbstractProjectile projectile;
        public ProjectileEnemyCollision(AbstractEnemy enemy, AbstractProjectile projectile)
        {
            this.enemy = enemy;
            this.projectile = projectile;   
        }
        public override void ResolveCollision() {
            LevelGameState.KillEnemy(enemy);
            projectile.Die();
        }
    }
}
