using System;
using System.Collections.Generic;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;
using CPUEngine.Engine;
using CPUEngine.Game;

namespace CPUEngine
{
    public partial class MainWindow : Form
    {
        //Timer that controls rendering, other synced tasks (ex: player movement, physics)
        public static int frametime = 16;   //Put in the optimal frametime (60 FPS => 16ms, 30FPS => 33ms)
        System.Timers.Timer timer = new System.Timers.Timer(frametime);

        //Input
        public static List<int> keys = new List<int>();
        public static Point windowPosition = new Point();

        //custom
        #region
        Bitmap bg = new Bitmap(@"./bg.jpg");
        #endregion

        //Startup init
        public MainWindow()
        {
            InitializeComponent();
            EngineGraphics.Init(1280, 720);

            //Get correct window position
            ResizeEnd += new EventHandler(WindowMoved); 

            //Set up Key Management
            KeyDown += new KeyEventHandler(ManageKeysDown);
            KeyUp += new KeyEventHandler(ManageKeysUp);

            pictureBox1.MouseDown += new MouseEventHandler(ManageMouseDown);
            pictureBox1.MouseUp += new MouseEventHandler(ManageMouseUp);
        }

        //After startup init
        private void Form1_Load(object sender, EventArgs e)
        {
            windowPosition = new Point(Left, Top);

            timer.Elapsed += new ElapsedEventHandler(Render);
            timer.AutoReset = true;
            timer.Enabled = true;

            //custom
            #region

            timer.Elapsed += new ElapsedEventHandler(Player.PlayerMove);
            timer.Elapsed += new ElapsedEventHandler(World.MoveEnemys);

            //int musicP = EngineAudio.CreatePlayer();
            //EngineAudio.AddSound("music", @"./xd.wav");
            //EngineAudio.Play("music", musicP);

            EngineGraphics.sprites.Add("minecraft", new Bitmap(@"./minecraft.png"));
            EngineGraphics.brushes.Add("white",new SolidBrush(Color.White));

            EnginePhysics.colliders.Add(World.world);
            EngineOBJManager.objects.Add(World.world);

            EnginePhysics.colliders.Add(World.enemyOBJ);
            EngineOBJManager.objects.Add(World.enemyOBJ);
            World.enemys.Add(World.enemyOBJ);
            #endregion
        }

        //Input management
        #region
        private void ManageKeysDown(object sender, KeyEventArgs e)
        {
            if (!keys.Contains(e.KeyValue)) keys.Add(e.KeyValue);
        }

        private void ManageMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Left")
            {
                if (!keys.Contains(-1)) keys.Add(-1);
            }
            else if (e.Button.ToString() == "Middle")
            {
                if (!keys.Contains(-3)) keys.Add(-3);
            }
            else if (e.Button.ToString() == "Right")
            {
                if (!keys.Contains(-2)) keys.Add(-2);
            }
        }

        private void ManageKeysUp(object sender, KeyEventArgs e)
        {
            if (keys.Contains(e.KeyValue)) keys.Remove(e.KeyValue);
        }

        private void ManageMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString() == "Left")
            {
                if (keys.Contains(-1)) keys.Remove(-1);
            }
            else if (e.Button.ToString() == "Middle")
            {
                if (keys.Contains(-3)) keys.Remove(-3);
            }
            else if (e.Button.ToString() == "Right")
            {
                if (keys.Contains(-2)) keys.Remove(-2);
            }
        }

        public static Point GetCursor()
        {
            return new Point(Cursor.Position.X - windowPosition.X - 8, Cursor.Position.Y - windowPosition.Y - 30);
        }

        public void WindowMoved(object sender, EventArgs e)
        {
            windowPosition = new Point(Left,Top);
        }
        #endregion

        //Rendering loop
        private void Render(object sender, ElapsedEventArgs e)
        {
            //Clearing
            EngineGraphics.ClearBufferWithImage(bg);

            foreach(EngineOBJManager.OBJ temp in EngineOBJManager.objects)
            {
                if (temp.drawType == 1)
                {
                    EngineGraphics.DrawRectangleImageExtra(temp.garphics, temp.angle, temp.flipx, temp.flipy, EngineGraphics.sprites[temp.grapicsName]);
                }
                else if(temp.drawType == 2)
                {
                    EngineGraphics.DrawRectangleBrush(temp.garphics, EngineGraphics.brushes[temp.grapicsName]);
                }
            }

            //Draw player on top of everything
            EngineGraphics.DrawRectangleCoordinatesImageExtra(Player.x, Player.y, 100, 100, 0, -1, 1, EngineGraphics.sprites["minecraft"]);

            //Show new image
            pictureBox1.Image = EngineGraphics.buffers[EngineGraphics.currentBuffer];

            //Finished rendering, switch buffers
            EngineGraphics.SwitchBuffers();
        }
    }
}
