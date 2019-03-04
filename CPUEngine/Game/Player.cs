using System;
using System.Timers;
using System.Drawing;
using CPUEngine.Engine;

namespace CPUEngine.Game
{
    public class Player
    {
        //Physics
        public static int x = 100;
        public static int y = 100;
        private static int speed = 200; // px/sec

        private static float jumpTimer = 0;
        private static float jumpTimerMax = 16*30;
        private static int jumpSpeed = 200;
        private static int gravity = 200;
        

        public static Rectangle collBottom = new Rectangle(x+10, y+90, 80, 10);
        public static Rectangle collTop = new Rectangle(x+10, y, 80, 10);
        public static Rectangle collLeft = new Rectangle(x, y+10, 10, 80);
        public static Rectangle collRight = new Rectangle(x+90, y+10, 10, 80);

        public int points = 0;


        //called every frame by timer from MainWindow
        public static void PlayerMove(object sender, ElapsedEventArgs e)
        {
            //if (MainWindow.keys.Contains(87) && EnginePhysics.RectangleCollision(collTop) == -1) y -= speed / MainWindow.frametime;
            //if (MainWindow.keys.Contains(83) && EnginePhysics.RectangleCollision(collBottom) == -1) y += speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(65) && EnginePhysics.RectangleCollision(collLeft) == -1) x -= speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(68) && EnginePhysics.RectangleCollision(collRight) == -1) x += speed / MainWindow.frametime;

            PlayerJump();

            //Update colliders
            collBottom.X = x+10;
            collBottom.Y = y+90;

            collTop.X = x+10;
            collTop.Y = y;

            collLeft.X = x;
            collLeft.Y = y+10;

            collRight.X = x+90;
            collRight.Y = y+10;
        }

        private static void PlayerJump()
        {
            if (MainWindow.keys.Contains(87) && EnginePhysics.RectangleCollision(collTop) == -1 && jumpTimer < jumpTimerMax)
            {
                jumpTimer += MainWindow.frametime;
                Console.WriteLine(jumpTimer);
                y -= jumpSpeed / MainWindow.frametime;
            }
            if (EnginePhysics.RectangleCollision(collBottom) == -1)
            {
                if (EnginePhysics.RectangleCollision(collTop) != -1)
                {
                    jumpTimer = jumpTimerMax + 100;
                }
                y += gravity / MainWindow.frametime;
            }
            else if (EnginePhysics.RectangleCollision(collBottom) != -1)
            {
                jumpTimer = 0;
            }
        }
    }
}
