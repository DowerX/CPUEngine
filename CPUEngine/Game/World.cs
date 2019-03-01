using System.Drawing;
using CPUEngine.Engine;

namespace CPUEngine.Game
{
    public class World
    {
        public static Rectangle coll = new Rectangle(0, 710, 1280, 10);

        public static void DrawWorld()
        {
            EngineGraphics.DrawRectangleBrush(coll,EngineGraphics.brush);
        }
    }
}