using System.Drawing;
using System.Collections.Generic;

namespace CPUEngine.Engine
{
    public class EnginePhysics
    {
        public static List<EngineOBJManager.OBJ> colliders = new List<EngineOBJManager.OBJ>();

        public static int RectangleCollision(Rectangle rect)
        {
            for(int i = 0; i < colliders.Count; i++)
            {
                if(colliders[i].collider != null)
                {
                    if (colliders[i].collider.IntersectsWith(rect)) return i;
                }
            }
            return -1;
        }
    }
}
