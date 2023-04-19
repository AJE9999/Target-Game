using Untitled_Project.Collisions;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.Sprites.Blocks;

namespace Untitled_Project.GameObject
{
    internal class BlueBlock : AbstractBlock
    {
        public BlueBlock(int x, int y) : base(x,y)
        {
            sprite = new BlueBlockSprite();
            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }
    }
}
