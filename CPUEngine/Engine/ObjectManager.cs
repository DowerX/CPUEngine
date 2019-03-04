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
            //Informations
            public int id;
            public List<string> tags;

            //Graphcis
            public float angle = 0;
            public int flipx = 1;
            public int flipy = 1;
            public int drawType = 1;
            public Rectangle garphics;
            public string grapicsName;

            //Physics
            public Rectangle collider;


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
