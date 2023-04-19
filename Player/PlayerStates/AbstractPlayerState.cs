using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Sprites;

namespace Untitled_Project.Player.PlayerStates
{
    internal abstract class AbstractPlayerState
    {
        public AbstractSprite sprite { get; set; }
        protected PlayerCharacter player;
        protected AbstractPlayerState(PlayerCharacter player)
        {
            this.player = player;
        }
        public virtual void Draw(int x, int y) { sprite.Draw(x, y); }
        public virtual void Update() { sprite.Update(); }
    }
}
