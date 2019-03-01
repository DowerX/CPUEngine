using System.Drawing;
using CPUEngine.Engine;

namespace CPUEngine.Game
{
    public class World
    {
        public static Rectangle coll = new Rectangle(0, 710, 1280, 10);

        public static EngineOBJManager.OBJ world = new EngineOBJManager.OBJ { id = 0,collider=coll,garphics=coll,drawType=2,grapicsName="white"};
        public static Rectangle xd = new Rectangle(0, 300, 640, 20);
        public static EngineOBJManager.OBJ world1 = new EngineOBJManager.OBJ { id = 1,collider=xd,garphics=xd,drawType=2,grapicsName="white"};
    }
}