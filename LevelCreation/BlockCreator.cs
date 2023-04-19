using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Untitled_Project.GameObject;
using Untitled_Project.GameObject.Blocks;

namespace Untitled_Project.LevelCreation
{
    public static class BlockCreator
    {
        public static AbstractBlock createBlock(string s, int x, int y)
        {
            switch (s)
            {
                case "WallBlock":
                    return new WallBlock(x, y);
                case "RedBlock":
                    return new RedBlock(x, y);
                case "GreenBlock":
                    return new GreenBlock(x, y);
                case "BlueBlock":
                    return new BlueBlock(x, y);
                default:
                    return new WallBlock(x, y);
            }
        }
    }
}
