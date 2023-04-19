using Microsoft.Xna.Framework;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.GameObject.Misc;

namespace Untitled_Project.Collisions.CollisionTypes
{
    internal class ProjectileTerrainCollision : AbstractCollision
    {
        private AbstractBlock terrainObj;
        private AbstractProjectile projectile;
        public ProjectileTerrainCollision(AbstractBlock terrainObj, AbstractProjectile projectile)
        {
            this.terrainObj = terrainObj;
            this.projectile = projectile;   
        }
        public override void ResolveCollision() {
            //resolve terrain part of the collision by telling the block it was hit
            terrainObj.OnHit();

            //resolve the projectile part of the collision
            Rectangle intersection = Rectangle.Intersect(terrainObj.hitbox, projectile.hitbox);
            bool directionOfCollision = intersection.Width < intersection.Height;
            projectile.OnHit(directionOfCollision);
        }
    }
}
