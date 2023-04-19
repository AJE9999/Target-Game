using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Untitled_Project.DrawHelpers
{
    public static class DrawHelperManager
    {
        public static void Initialize(int width, int height)
        {
            DrawHelperMenu.Initialize(width, height);
            DrawHelperBackground.Initialize(width, height);
        }
    }
}
