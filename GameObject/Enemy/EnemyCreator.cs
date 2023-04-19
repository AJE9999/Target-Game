using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.GameObject.Enemy
{
    public static class EnemyCreator
    {
        public static AbstractEnemy createEnemy(string s, int x, int y)
        {
            switch(s)
            {
                case "Target":
                    return new Target(x, y);
                default:
                    return new Target(x, y);
            }
        }
    }
}
