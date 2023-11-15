using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public interface IGraphics
    {
        //清除整個畫面
        void ClearAll();
        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        //畫矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //畫圓形
        void DrawEllipse(double x1, double y1, double x2, double y2);

        //畫線
        void DrawBorder(double x1, double y1, double x2, double y2);

    }
}
