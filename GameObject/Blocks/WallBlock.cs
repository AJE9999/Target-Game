using Untitled_Project.Collisions;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.Sprites.Blocks;

namespace Untitled_Project.GameObject
{
    internal class WallBlock : AbstractBlock
    {
        public WallBlock(int x, int y) : base(x,y)
        {
            sprite = new WallBlockSprite();
            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }
    }
}
