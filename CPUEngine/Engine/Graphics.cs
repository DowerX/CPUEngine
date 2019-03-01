using System.Drawing;
using System;

//REMEMBER: THE ORIGO (0,0) IS THE TOP LEFT CORNER!
//CLOCKVISE IS THE POSITVE DIRECTION FOR ROTATING

namespace CPUEngine.Engine
{
    public class EngineGraphics
    {
        public static Bitmap screen = new Bitmap(1280, 720);
        static Bitmap buffer = new Bitmap(1280, 720);

        static Graphics g = Graphics.FromImage(buffer);

        //custom
        #region
        public static SolidBrush brush = new SolidBrush(Color.White);
        public static Bitmap mc = new Bitmap(@"./minecraft.png");
        public static Bitmap bgx = new Bitmap(@"./bgx.jpg");
        public static TextureBrush bgxBrush = new TextureBrush(bgx);
        #endregion

        public static void CopyBuffer()
        {
            screen = buffer;
        }

        public static void ClearBufferSolid(Color color)
        {
            g.Clear(color);
        }

        public static void ClearBufferWithImage(Bitmap img)
        {
            g.DrawImageUnscaled(img, 0, 0);
        }

        public static void DrawRectangleBrush(int x, int y, int w, int h, Brush b)
        {
            g.FillRectangle(b, x, y, w, h);
        }

        public static void DrawRectangleImage(int x, int y, int w, int h, Bitmap img)
        {
            g.DrawImage(img, x, y, w, h);
        }

        public static void DrawRectangleImageExtra(int x, int y, int w, int h, float angle, int flipx, int flipy, Bitmap img)
        {
            using (Bitmap temp = new Bitmap(w, h))
            {
                using (Graphics _g = Graphics.FromImage(temp))
                {
                    _g.TranslateTransform((float)w / 2, (float)h / 2);
                    _g.RotateTransform(angle * flipx * flipy);
                    _g.DrawImage(img, -(float)w / 2, -(float)h / 2, w, h);
                }
                if (flipx == -1) temp.RotateFlip(RotateFlipType.Rotate180FlipX);
                if (flipy == -1) temp.RotateFlip(RotateFlipType.Rotate180FlipY);
                g.DrawImage(temp, x, y, w, h);
            }
        }
    }
}
