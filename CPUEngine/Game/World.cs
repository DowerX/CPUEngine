using System.Collections.Generic;
using System.Drawing;
using CPUEngine.Engine;
using System.Timers;
using System;
using System.IO;

namespace CPUEngine.Game
{
    public class World
    {
        //manual
        #region
        //public static Rectangle world = new Rectangle(0, 710, 1280, 10);
        //public static EngineOBJManager.OBJ worldOBJ = new EngineOBJManager.OBJ { id = 0,collider=world,garphics=world, drawType=2,grapicsName="white"};

        //public static Rectangle enemy = new Rectangle(300, 300, 50, 50);
        //public static EngineOBJManager.OBJ enemyOBJ = new EngineOBJManager.OBJ { id = 1,collider= enemy, garphics= enemy, drawType=2,flipx= 1 ,grapicsName="white", tags = new List<string> {"enemy"} };

        //public static Rectangle wallLeft = new Rectangle(0, 0, 10, 720);
        //public static Rectangle wallRight = new Rectangle(1270, 0, 10, 720);
        //public static EngineOBJManager.OBJ wallLeftOBJ = new EngineOBJManager.OBJ { id = 2, collider = wallLeft, garphics = wallLeft, drawType = 2, grapicsName = "white" };
        //public static EngineOBJManager.OBJ wallRightOBJ = new EngineOBJManager.OBJ { id = 3, collider = wallRight, garphics = wallRight, drawType = 2, grapicsName = "white" };

        #endregion

        //private static List<EngineOBJManager.OBJ> elements = new List<EngineOBJManager.OBJ>();
        
        public static List<EngineOBJManager.OBJ> enemys = new List<EngineOBJManager.OBJ>();
        private static int enemySpeed = 10;

        public static void LoadWorld(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] parts = line.Split(" ".ToCharArray());

                try
                {
                    EngineOBJManager.OBJ temp = new EngineOBJManager.OBJ {drawType=1,
                        collider = new Rectangle(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])),
                        garphics = new Rectangle(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])),
                        angle= int.Parse(parts[5]), tags= new List<string> {parts[6]} };

                    EngineOBJManager.objects.Add(temp);
                    EnginePhysics.colliders.Add(temp);

                    if (parts[6] == "enemy") enemys.Add(temp);
                }
                catch
                {
                    Console.WriteLine("Error while reading from file " + path + " .");
                }
            }
        }

        public static void MoveEnemys(object sender, ElapsedEventArgs e)
        {
            foreach(EngineOBJManager.OBJ temp in enemys)
            {
                if (EnginePhysics.RectangleCollision(temp.collider) != -1)
                {
                    Console.WriteLine(temp.flipx);
                    if (temp.flipx == 1)
                    {
                        temp.flipx = -1;
                    }
                    else
                    {
                        temp.flipx = 1;
                    }

                    temp.collider.X += (temp.flipx * enemySpeed); // / MainWindow.frametime;
                    temp.garphics.X += (temp.flipx * enemySpeed); // / MainWindow.frametime;
                }
                else
                {
                    temp.collider.X += (temp.flipx * enemySpeed); // / MainWindow.frametime;
                    temp.garphics.X += (temp.flipx * enemySpeed); // / MainWindow.frametime;
                }
            }
        }
    }
}