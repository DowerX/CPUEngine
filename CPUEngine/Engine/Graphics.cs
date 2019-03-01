using System.Drawing;
using System.Collections.Generic;

//REMEMBER: THE ORIGO (0,0) IS THE TOP LEFT CORNER!
//CLOCKVISE IS THE POSITVE DIRECTION FOR ROTATING

namespace CPUEngine.Engine
{
    public class EngineGraphics
    {
        public static int currentBuffer = 0;

        public static Bitmap[] buffers = new Bitmap[2];
        static Graphics[] g = new Graphics[2];

        public static Dictionary<string, Bitmap> sprites = new Dictionary<string, Bitmap>();
        public static Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        //custom
        #region
        //public static SolidBrush brush = new SolidBrush(Color.White);
        //public static Bitmap mc = new Bitmap(@"./minecraft.png");
        //public static Bitmap bgx = new Bitmap(@"./bgx.jpg");
        //public static TextureBrush bgxBrush = new TextureBrush(bgx);
        #endregion

        public static bool Init(int w, int h)
        {
            try
            {
                buffers[0] = new Bitmap(w, h);
                buffers[1] = new Bitmap(w, h);
                g[0] = Graphics.FromImage(buffers[0]);
                g[1] = Graphics.FromImage(buffers[1]);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static void SwitchBuffers()
        {
            if (currentBuffer == 0) currentBuffer = 1;
            else currentBuffer = 0;
        }

        public static void ClearBufferSolid(Color color)
        {
            g[currentBuffer].Clear(color);
        }

        public static void ClearBufferWithImage(Bitmap img)
        {
            g[currentBuffer].DrawImageUnscaled(img, 0, 0);
        }

        //Rectangle by coordinates
        #region
        public static void DrawRectangleCoordinatesBrush(int x, int y, int w, int h, Brush b)
        {
            g[currentBuffer].FillRectangle(b, x, y, w, h);
        }

        public static void DrawRectangleCoordinatesImage(int x, int y, int w, int h, Bitmap img)
        {
            g[currentBuffer].DrawImage(img, x, y, w, h);
        }

        public static void DrawRectangleCoordinatesImageExtra(int x, int y, int w, int h, float angle, int flipx, int flipy, Bitmap img)
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
                g[currentBuffer].DrawImage(temp, x, y, w, h);
            }
        }
        #endregion

        //Rectangle
        #region
        public static void DrawRectangleBrush(Rectangle rect, Brush b)
        {
            g[currentBuffer].FillRectangle(b, rect);
        }

        public static void DrawRectangleImage(Rectangle rect, Bitmap img)
        {
            g[currentBuffer].DrawImage(img, rect);
        }

        public static void DrawRectangleImageExtra(Rectangle rect, float angle, int flipx, int flipy, Bitmap img)
        {
            using (Bitmap temp = new Bitmap(rect.Width, rect.Height))
            {
                using (Graphics _g = Graphics.FromImage(temp))
                {
                    _g.TranslateTransform((float)rect.Width / 2, (float)rect.Height / 2);
                    _g.RotateTransform(angle * flipx * flipy);
                    _g.DrawImage(img, -(float)rect.Width / 2, -(float)rect.Height / 2, rect.Width, rect.Height);
                }
                if (flipx == -1) temp.RotateFlip(RotateFlipType.Rotate180FlipX);
                if (flipy == -1) temp.RotateFlip(RotateFlipType.Rotate180FlipY);
                g[currentBuffer].DrawImage(temp, rect.X, rect.Y, rect.Width, rect.Width);
            }
        }
        #endregion
    }
}
