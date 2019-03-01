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
        public static int frametime = 17;   //Put in the optimal frametime (60 FPS => 16ms (but use 17ms pls), 30FPS => )
        System.Timers.Timer timer = new System.Timers.Timer(frametime);

        //Key states
        public static List<int> keys = new List<int>();

        //custom
        #region
        Bitmap bg = new Bitmap(@"./bg.jpg");
        #endregion

        //Startup init
        public MainWindow()
        {
            InitializeComponent();

            //Set up Key Management
            KeyDown += new KeyEventHandler(ManageKeysDown);
            KeyUp += new KeyEventHandler(ManageKeysUp);
        }

        //After startup init
        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Elapsed += new ElapsedEventHandler(Render);
            timer.AutoReset = true;
            timer.Enabled = true;

            //custom
            #region

            timer.Elapsed += new ElapsedEventHandler(Player.PlayerMove);
            int musicP = EngineAudio.CreatePlayer();
            EngineAudio.AddSound("music", @"./xd.wav");
            EngineAudio.Play("music", musicP);


            //EnginePhysics.colliders.Add(World.coll);
            #endregion
        }

        //Input management
        #region
        private void ManageKeysDown(object sender, KeyEventArgs e)
        {
            if (!keys.Contains(e.KeyValue)) keys.Add(e.KeyValue);
        }

        private void ManageKeysUp(object sender, KeyEventArgs e)
        {
            if (keys.Contains(e.KeyValue)) keys.Remove(e.KeyValue);
        }
        #endregion

        //Rendering loop
        private void Render(object sender, ElapsedEventArgs e)
        {
            //Clearing
            //EngineGraphics.ClearBufferSolid(Color.Black);
            EngineGraphics.ClearBufferWithImage(bg);

            //EngineGraphics.DrawRectangleBrush(Player.y, Player.x, 100, 100, EngineGraphics.brush);
            EngineGraphics.DrawRectangleImageExtra(Player.x, Player.y, 100, 100, Player.r, -1, 1, EngineGraphics.mc);
            World.DrawWorld();

            //Finished rendering
            EngineGraphics.CopyBuffer();

            //Show new image
            pictureBox1.Image = EngineGraphics.screen;
        }
    }
}
