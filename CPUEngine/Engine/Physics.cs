using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUEngine.Engine
{
    public static class EnginePhysics
    {
        public static List<Rectangle> colliders = new List<Rectangle>();

        public static bool RectangleCollision(Rectangle rect)
        {
            foreach(Rectangle temp in colliders)
            {
                temp.Intersect(rect);
                if(temp.IsEmpty) return true;
            }
            return false;
        }
    }
}
