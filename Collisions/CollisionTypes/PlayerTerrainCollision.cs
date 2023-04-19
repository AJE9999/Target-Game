using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.GameObject;

namespace Untitled_Project.Collisions.CollisionTypes
{
    internal class PlayerTerrainCollision : AbstractCollision
    {
        private AbstractGameObject terrainObj;
        private AbstractGameObject player;
        public PlayerTerrainCollision(AbstractGameObject terrainObj, AbstractGameObject player)
        {
            this.terrainObj = terrainObj;
            this.player = player;   
        }
        public override void ResolveCollision() {
            if (player.hitbox.Right > terrainObj.hitbox.Right)
                player.x = terrainObj.hitbox.Right;
            else
                player.x = terrainObj.hitbox.Left - player.hitbox.Width;
        }
    }
}
