using Untitled_Project.Collisions;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.GameObject.Misc;
using Untitled_Project.Sprites.Blocks;

namespace Untitled_Project.GameObject
{
    internal class RedBlock : AbstractBlock
    {
        public RedBlock(int x, int y) : base(x,y)
        {
            sprite = new RedBlockSprite();
            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }
    }
}
