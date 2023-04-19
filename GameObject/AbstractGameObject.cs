using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.Sprites;
using Untitled_Project.Sprites.Blocks;

namespace Untitled_Project.GameObject
{
    public abstract class AbstractGameObject
    {
        public AbstractSprite sprite { get; set; }
        public Rectangle hitbox { get; set; }
        public int x, y;

        public AbstractGameObject(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public virtual void Draw()
        {
            sprite.Draw(x, y);
        }
        public virtual void Update() { }
    }
}
