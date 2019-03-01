using System.Drawing;
using System.Collections.Generic;

namespace CPUEngine.Engine
{
    public class EnginePhysics
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
