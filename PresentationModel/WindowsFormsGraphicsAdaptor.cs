using System.Drawing;
using System;
namespace PowerPoint.PresentationModel
{
    internal class WindowsFormsGraphicsAdaptor : CustomGraphics
    {
        private Graphics _graphics;

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
            //this._bitmap = new Bitmap((int)graphics.VisibleClipBounds.Width, (int)graphics.VisibleClipBounds.Height);
        }

        //清除整個畫面
        public void ClearAll()
        {
        }

        //畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫橢圓

        void CustomGraphics.DrawEllipse(double x1, double y1, double x2, double y2)
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            double left = Math.Min(x1, x2);
            double top = Math.Min(y1, y2);
            _graphics.DrawEllipse(Pens.Black, (float)left, (float)top, (float)width, (float)height);
        }

        //畫長方形

        void CustomGraphics.DrawRectangle(double x1, double y1, double x2, double y2)
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            double left = Math.Min(x1, x2);
            double top = Math.Min(y1, y2);
            _graphics.DrawRectangle(Pens.Black, (float)left, (float)top, (float)width, (float)height);
        }

        //畫選擇邊框
        void CustomGraphics.DrawBorder(double x1, double y1, double x2, double y2)
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            double left = Math.Min(x1, x2);
            double top = Math.Min(y1, y2);
            _graphics.DrawRectangle(Pens.Red, (float)left, (float)top, (float)width, (float)height);
            DrawCornerEllipse(left, top);
            DrawCornerEllipse(left + width, top);
            DrawCornerEllipse(left, top + height);
            DrawCornerEllipse(left + width, top + height);
            DrawCornerEllipse(left + width / 2, top);
            DrawCornerEllipse(left, top + height / 2);
            DrawCornerEllipse(left + width, top + height / 2);
            DrawCornerEllipse(left + width / 2, top + height);
        }
        // 畫邊框
        private void DrawCornerEllipse(double x, double y)
        {
            // Draw a small ellipse at the specified corner
            _graphics.DrawEllipse(Pens.Black, (float)x - 5, (float)y - 5, 10, 10);
        }
    }
}