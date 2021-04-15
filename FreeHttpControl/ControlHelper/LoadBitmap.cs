using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeHttp.FreeHttpControl.ControlHelper
{
    class LoadBitmap
    {
        //private int count = -1;
        //private ArrayList images = new ArrayList();
        //public Bitmap[] bitmap = new Bitmap[8];
        private int _value = 1;
        private Color _circleColor = Color.Red;
        private float _circleSize = 0.8f;
        private int Width;
        private int Height;

        public LoadBitmap(Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        internal void SetSize(int size)
        {
            SetSize(new Size(size, size));
        }
        public void SetSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }

        public Bitmap DrawCircle(int j)
        {
            const float angle = 360.0F / 8; Bitmap map = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(map);

            g.TranslateTransform(Width / 2.0F, Height / 2.0F);
            g.RotateTransform(angle * _value);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int[] a = new int[8] { 25, 50, 75, 100, 125, 150, 175, 200 };
            for (int i = 1; i <= 8; i++)
            {
                int alpha = a[(i + j - 1) % 8];
                Color drawColor = Color.FromArgb(alpha, _circleColor);
                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    float sizeRate = 3.5F / _circleSize;
                    float size = Width / (6 * sizeRate);

                    float diff = (Width / 10.0F) - size;

                    float x = (Width / 80.0F) + diff;
                    float y = (Height / 80.0F) + diff;
                    g.FillEllipse(brush, x, y, size, size);
                    g.RotateTransform(angle);
                }
            }
            //g.DrawLine(new Pen(Color.Red),1,1,10,10);
            //g.Save();
            return map;
        }

        
    }
}
