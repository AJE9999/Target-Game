using Microsoft.Xna.Framework;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Collisions.CollisionTypes;
using Untitled_Project.GameObject;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.GameObject.Enemy;
using Untitled_Project.GameObject.Misc;
using Untitled_Project.Player;

namespace Untitled_Project.Collisions
{
    internal class CollisionManager
    {

        public void CollisionCheck(List<AbstractBlock> terrain, List<AbstractEnemy> enemies, List<AbstractProjectile> playerProjectiles, List<AbstractProjectile> enemyProjectiles, AbstractGameObject player)
        {
            // Player vs Terrain
            List<AbstractCollision> collisions = GetPlayerTerrainCollisions(terrain, player);
            collisions.ForEach(x => x.ResolveCollision());

            // Enemy vs Terrain
            collisions = GetEnemyTerrainCollisions(terrain, enemies);
            collisions.ForEach(x => x.ResolveCollision());

            // Player Projectiles vs Terrain, Enemy
            collisions = GetProjectileTerrainCollisions(terrain, playerProjectiles);
            collisions.ForEach(x => x.ResolveCollision());

            collisions = GetProjectileEnemyCollisions(enemies, playerProjectiles);
            collisions.ForEach(x => x.ResolveCollision());
        }

        private static List<AbstractCollision> GetPlayerTerrainCollisions(List<AbstractBlock> terrain, AbstractGameObject player)
        {
            List<AbstractCollision> collisions = new List<AbstractCollision>();
            foreach (AbstractGameObject t in terrain)
            {
                if (player.hitbox.Intersects(t.hitbox))
                    collisions.Add(new PlayerTerrainCollision(t, player));
            }
            return collisions;
        }

        private List<AbstractCollision> GetEnemyTerrainCollisions(List<AbstractBlock> terrain, List<AbstractEnemy> enemies)
        {
            List<AbstractCollision> collisions = new List<AbstractCollision>();
            foreach (AbstractEnemy e in enemies)
                foreach (AbstractGameObject t in terrain)
                {
                    if (e.hitbox.Intersects(t.hitbox))
                    {
                        collisions.Add(new EnemyTerrainCollision(t, e));
                        break;
                    }
                }
            return collisions;
        }

        private List<AbstractCollision> GetProjectileTerrainCollisions(List<AbstractBlock> terrain, List<AbstractProjectile> projectiles)
        {
            List<AbstractCollision> collisions = new List<AbstractCollision>();
            foreach (AbstractProjectile p in projectiles)
                foreach (AbstractBlock t in terrain)
                {
                    if (p.hitbox.Intersects(t.hitbox))
                    {
                        collisions.Add(new ProjectileTerrainCollision(t, p));
                        break;
                    }
                }
            return collisions;
        }

        private List<AbstractCollision> GetProjectileEnemyCollisions(List<AbstractEnemy> enemies, List<AbstractProjectile> projectiles)
        {
            List<AbstractCollision> collisions = new List<AbstractCollision>();
            foreach (AbstractProjectile p in projectiles)
                foreach (AbstractEnemy e in enemies)
                {
                    if (p.hitbox.Intersects(e.hitbox))
                    {
                        collisions.Add(new ProjectileEnemyCollision(e, p));
                        break;
                    }
                }
            return collisions;
        }
    }
}
