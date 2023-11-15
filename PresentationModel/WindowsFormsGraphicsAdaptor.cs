using System.Drawing;
namespace HW2.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
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

        void IGraphics.DrawEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫長方形

        void IGraphics.DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫選擇邊框
        void IGraphics.DrawBorder(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Red, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}