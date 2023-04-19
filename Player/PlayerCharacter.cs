using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.GameObject;
using Untitled_Project.Sprites;
using Untitled_Project.Sprites.Blocks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using SharpDX.Direct2D1;
using Microsoft.Xna.Framework;
using Untitled_Project.Player.PlayerStates;
using Untitled_Project.GameObject.Projectiles;
using Untitled_Project.Collisions;

namespace Untitled_Project.Player
{

    internal class PlayerCharacter : AbstractGameObject
    {
        public AbstractPlayerState state;
        public int speed = 4;
        public PlayerCharacter(int x, int y) : base(x,y)
        {
            state = new IdlePlayerState(this);
            hitbox = CollisionHelper.Hitbox(x, y, state.sprite);
        }
        public new void Draw()
        {
            state.Draw(x, y);
        }
        public new void Update()
        {
            
            /*******************DEBUGGING***********************/
            if(MyKeyboard.WasKeyPressed(Keys.Space))
            {
                ShootProjectile();
            }
            /*******************DEBUGGING***********************/

            state.Update();

            // update hitbox
            hitbox = CollisionHelper.Hitbox(x, y, state.sprite);
        }

        private void ShootProjectile() {
            //get vector from player to mouse
            Vector2 dir = Vector2.Subtract(new Vector2(x, y), new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
            LevelGameState.SpawnPlayerProjectile(new SimpleProjectile(x, y, dir));
        }
    }
}
