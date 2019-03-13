using System;
using System.Timers;
using System.Drawing;
using CPUEngine.Engine;

namespace CPUEngine.Game
{
    public class Player
    {
        //Physics
        public static int x = 500;
        public static int y = 300;
        private static int speed = 200; // px/sec

        private static float jumpTimer = 0;
        private static float jumpTimerMax = 16*30;
        private static int jumpSpeed = 200;
        private static int gravity = 200;

        public static Rectangle collBottom = new Rectangle(x+10, y+90, 80, 10);
        public static Rectangle collTop = new Rectangle(x+10, y, 80, 10);
        public static Rectangle collLeft = new Rectangle(x, y+10, 10, 80);
        public static Rectangle collRight = new Rectangle(x+90, y+10, 10, 80);

        public static int points = 0;


        //called every frame by timer from MainWindow
        public static void PlayerMove(object sender, ElapsedEventArgs e)
        {
            x = 0;
            if (MainWindow.keys.Contains(65) && EnginePhysics.RectangleCollision(collLeft) == -1) x -= speed / MainWindow.frametime;
            if (MainWindow.keys.Contains(68) && EnginePhysics.RectangleCollision(collRight) == -1) x += speed / MainWindow.frametime;

            PlayerJump();
            CheckCollisions();

            //Update colliders
            //collBottom.X = x+10;
            collBottom.Y = y+90;

            //collTop.X = x+10;
            collTop.Y = y;

            //collLeft.X = x;
            collLeft.Y = y+10;

            //collRight.X = x+90;
            collRight.Y = y+10;

            foreach(EngineOBJManager.OBJ temp in EngineOBJManager.objects)
            {
                if(temp.tags.Contains("world") || temp.tags.Contains("enemy"))
                {
                    temp.garphics.X -= x;
                    temp.collider.X -= x;
                }
            }
        }

        private static void CheckCollisions()
        {
            int left = EnginePhysics.RectangleCollision(collLeft);
            int right = EnginePhysics.RectangleCollision(collRight);
            int bottom = EnginePhysics.RectangleCollision(collBottom);
            int top = EnginePhysics.RectangleCollision(collTop);

            if (left != -1)
            {
                EngineOBJManager.OBJ temp = EnginePhysics.colliders[left];
                if(temp.tags != null)
                {
                    if (temp.tags.Contains("point"))
                    {
                        points++;
                        Console.WriteLine("NEW POINT XD");
                        EngineOBJManager.objects.Remove(temp);
                        EnginePhysics.colliders.Remove(temp);
                    }
                    else if (temp.tags.Contains("enemy"))
                    {
                        Console.WriteLine("DEAD");
                    }
                    
                }
            }

            if (right != -1)
            {
                EngineOBJManager.OBJ temp = EnginePhysics.colliders[right];
                if (temp.tags != null)
                {
                    if (temp.tags.Contains("point"))
                    {
                        points++;
                        Console.WriteLine("NEW POINT XD");
                        EngineOBJManager.objects.Remove(temp);
                        EnginePhysics.colliders.Remove(temp);
                    }
                    else if (temp.tags.Contains("enemy"))
                    {
                        Console.WriteLine("DEAD");
                    }
                }
            }

            if (top != -1)
            {
                EngineOBJManager.OBJ temp = EnginePhysics.colliders[top];
                if (temp.tags != null)
                {
                    if (temp.tags.Contains("point"))
                    {
                        points++;
                        Console.WriteLine("NEW POINT XD");
                        EngineOBJManager.objects.Remove(temp);
                        EnginePhysics.colliders.Remove(temp);
                    }
                    else if (temp.tags.Contains("enemy"))
                    {
                        Console.WriteLine("DEAD");
                    }
                }
            }

            if (bottom != -1)
            {


                EngineOBJManager.OBJ temp = EnginePhysics.colliders[bottom];
                if (temp.tags != null)
                {
                    if (temp.tags.Contains("point"))
                    {
                        points++;
                        Console.WriteLine("NEW POINT XD");
                        EngineOBJManager.objects.Remove(temp);
                        EnginePhysics.colliders.Remove(temp);
                    }
                    else if (temp.tags.Contains("enemy"))
                    {
                        EngineOBJManager.objects.Remove(temp);
                        EnginePhysics.colliders.Remove(temp);
                    }
                }
            }
        }

        private static void PlayerJump()
        {
            if (MainWindow.keys.Contains(87) && EnginePhysics.RectangleCollision(collTop) == -1 && jumpTimer < jumpTimerMax)
            {
                jumpTimer += MainWindow.frametime;

                y -= jumpSpeed / MainWindow.frametime;
            }
            else if (EnginePhysics.RectangleCollision(collBottom) == -1)
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
