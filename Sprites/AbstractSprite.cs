using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.Sprites
{
    public abstract class AbstractSprite
    {
        public Rectangle source { get; set; }
        public Texture2D spritesheet { get; set; }

        public int scale = 1;
        
        public AbstractSprite(int scale)
        {
            this.scale = scale;
        }
        public virtual void Init() { }
        public virtual void Draw(int x, int y) { 
            GameMain.Instance.spriteBatch.Draw(
                spritesheet, 
                new Rectangle(x, y, source.Width * scale, source.Height * scale), 
                source, 
                Color.White
            ); 
        }

        public virtual void Update() { }
    }
}
