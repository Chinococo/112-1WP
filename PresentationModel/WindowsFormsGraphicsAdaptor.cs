using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        private Bitmap _bitmap;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
            this._bitmap = new Bitmap((int)graphics.VisibleClipBounds.Width, (int)graphics.VisibleClipBounds.Height);
        }
        //清除整個畫面
        public void ClearAll()
        {
            // Clear the bitmap
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.Clear(Color.White); // You can choose any background color
            }
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
            }
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫橢圓

        void IGraphics.DrawEllipse(double x1, double y1, double x2, double y2)
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
            }
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫長方形

        void IGraphics.DrawRectangle(double x1, double y1, double x2, double y2)
        {
            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
            }
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }
        Bitmap IGraphics.GetImage()
        {
            return _bitmap;
        }

    }
}
