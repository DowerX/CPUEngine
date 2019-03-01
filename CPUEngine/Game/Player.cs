﻿using System;
using System.Timers;
using System.Drawing;
using CPUEngine.Engine;

namespace CPUEngine.Game
{
    public class Player
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
            if (MainWindow.keys.Contains(87) && EnginePhysics.RectangleCollision(collTop) == -1) y -= speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(83) && EnginePhysics.RectangleCollision(collBottom) == -1) y += speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(65) && EnginePhysics.RectangleCollision(collLeft) == -1) x -= speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(68) && EnginePhysics.RectangleCollision(collRight) == -1) x += speed / MainWindow.frametime;

            Console.WriteLine(EnginePhysics.RectangleCollision(collBottom));

            //Update collider rectangle
            collBottom.X = x;
            collBottom.Y = y+90;

            collTop.X = x;
            collTop.Y = y;

            collLeft.X = x;
            collLeft.Y = y;

            collRight.X = x+90;
            collRight.Y = y;

            if (MainWindow.keys.Contains(-1)) r += rspeed / MainWindow.frametime;
        }
    }
}
