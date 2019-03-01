using System;
using System.Timers;
using System.Drawing;
using CPUEngine.Engine;

namespace CPUEngine.Game
{
    public static class Player
    {
        public static int x = 100;
        public static int y = 100;
        public static int speed = 200; // px/sec
        public static int rspeed = 90;

        public static int r = 0;

        public static Rectangle collBottom = new Rectangle(x+10, y+90, 80, 10);
        public static Rectangle collTop = new Rectangle(x+10, y, 80, 10);
        public static Rectangle collLeft = new Rectangle(x, y+10, 10, 80);
        public static Rectangle collRight = new Rectangle(x+90, y+10, 10, 80);


        //called every frame by timer from MainWindow
        public static void PlayerMove(object sender, ElapsedEventArgs e)
        {
            EngineGraphics.DrawRectangleBrush(x+10, y, 80, 10, EngineGraphics.brush);

            Rectangle tempBottom = Rectangle.Intersect(World.coll, collBottom);
            Rectangle tempTop = Rectangle.Intersect(World.coll, collTop);
            Rectangle tempLeft = Rectangle.Intersect(World.coll, collLeft);
            Rectangle tempRight = Rectangle.Intersect(World.coll, collRight);

            Console.WriteLine(tempBottom.IsEmpty);


            #region
            //if (!inter.IsEmpty) Console.WriteLine("COLLISION");

            //if (MainWindow.keys.Contains(87) && !EnginePhysics.RectangleCollisionTop(x,y,50)) x -= speed / MainWindow.frametime;
            //if (MainWindow.keys.Contains(83) && !EnginePhysics.RectangleCollisionBottom(x, y, 50,50)) x += speed / MainWindow.frametime;
            //if (MainWindow.keys.Contains(65) && !EnginePhysics.RectangleCollisionRight(x, y, 50,50)) y -= speed / MainWindow.frametime;
            //if (MainWindow.keys.Contains(68) && !EnginePhysics.RectangleCollisionLeft(x, y, 50,50)) y += speed / MainWindow.frametime;

            //Console.WriteLine("1" + EnginePhysics.RectangleCollisionTop(x, y, 50).ToString());
            //Console.WriteLine("2" + EnginePhysics.RectangleCollisionBottom(x, y, 50, 50).ToString());
            //Console.WriteLine("3" + EnginePhysics.RectangleCollisionRight(x, y, 50, 50).ToString());
            //Console.WriteLine("4" + EnginePhysics.RectangleCollisionLeft(x, y, 50, 50).ToString());
            #endregion
            if (MainWindow.keys.Contains(87) && tempTop.IsEmpty) y -= speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(83) && tempBottom.IsEmpty) y += speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(65) && tempLeft.IsEmpty) x -= speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(68) && tempRight.IsEmpty) x += speed / MainWindow.frametime;



            //Update collider rectangle
            collBottom.X = x;
            collBottom.Y = y+90;

            collTop.X = x;
            collTop.Y = y;

            collLeft.X = x;
            collLeft.Y = y;

            collRight.X = x+90;
            collRight.Y = y;

            if (MainWindow.keys.Contains(69)) r += rspeed / MainWindow.frametime;
        }
    }
}
