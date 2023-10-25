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
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2,
           (float)y2);
        }

        void IGraphics.DrawCircle(double x1, double y1, double x2, double y2)
        {
            throw new NotImplementedException();
        }

        void IGraphics.DrawRectangle(double x1, double y1, double x2, double y2)
        {
            throw new NotImplementedException();
        }
    }
}
