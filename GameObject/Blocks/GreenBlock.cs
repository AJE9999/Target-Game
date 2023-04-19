using Untitled_Project.Collisions;
using Untitled_Project.GameObject.Blocks;
using Untitled_Project.Sprites.Blocks;

namespace Untitled_Project.GameObject
{
    internal class GreenBlock : AbstractBlock
    {
        public GreenBlock(int x, int y) : base(x, y)
        {
            sprite = new GreenBlockSprite();
            hitbox = CollisionHelper.Hitbox(x, y, sprite);
        }

        public override void OnHit()
        {
            LevelGameState.KillTerrain(this);
        }
    }
}
