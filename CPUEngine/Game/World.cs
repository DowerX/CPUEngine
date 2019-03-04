using System.Collections.Generic;
using System.Drawing;
using CPUEngine.Engine;
using System.Timers;
using System;

namespace CPUEngine.Game
{
    public class World
    {
        public static Rectangle coll = new Rectangle(0, 710, 1280, 10);

        public static EngineOBJManager.OBJ world = new EngineOBJManager.OBJ { id = 0,collider=coll,garphics=coll,drawType=2,grapicsName="white"};

        public static Rectangle enemy = new Rectangle(300, 300, 50, 50);
        public static EngineOBJManager.OBJ enemyOBJ = new EngineOBJManager.OBJ { id = 1,collider= enemy, garphics= enemy, drawType=2,grapicsName="white", tags = new List<string> {"enemy"} };

        public static List<EngineOBJManager.OBJ> enemys = new List<EngineOBJManager.OBJ>();
        private static int enemySpeed = 200;

        public static void MoveEnemys(object sender, ElapsedEventArgs e)
        {
            foreach(EngineOBJManager.OBJ temp in enemys)
            {
                Console.WriteLine(temp.garphics.X);

                if (EnginePhysics.RectangleCollision(temp.collider) != -1)
                {
                    if (temp.flipy == 1)
                    {
                        temp.flipy = -1;
                    }
                    else
                    {
                        temp.flipy = 1;
                    }
                }
                else
                {

                    temp.collider.X += (temp.flipx * enemySpeed);// / MainWindow.frametime;
                    temp.garphics.X += (temp.flipx * enemySpeed);// / MainWindow.frametime;
                }
            }
        }
    }
}