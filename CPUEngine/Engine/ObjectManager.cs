using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUEngine.Engine
{
    public class EngineOBJManager
    {
        public static List<OBJ> objects = new List<OBJ>();

        public class OBJ
        {
            public int id;
            public float angle = 0;
            public int flipx = 1;
            public int flipy = 1;
            public Rectangle garphics;
            public Rectangle collider;
            public string grapicsName;
            public int drawType = 1;
        }

        public OBJ FindByID(List<OBJ> objs, int id)
        {
            foreach(OBJ obj in objs)
            {
                if (obj.id == id)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
