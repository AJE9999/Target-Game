using Microsoft.Xna.Framework;
using Untitled_Project.GameObject.Misc;
using Untitled_Project.Sprites;

namespace Untitled_Project.GameObject.Blocks
{
    public abstract class AbstractBlock : AbstractGameObject
    {
        public AbstractBlock(int x, int y) : base(x,y)
        {
        }
        public virtual void OnHit() { }
    }
}
