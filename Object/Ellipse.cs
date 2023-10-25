using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ellipse : Shape
{
    private const string NAME = "圓型";

    public Ellipse() : base(NAME)
    {
    }
    public override void Draw(IGraphics graphics)
    {
        double width = Math.Abs(x2 - x1);
        double height = Math.Abs(y2 - y1);
        double left = Math.Min(x1, x2);
        double top = Math.Min(y1, y2);
        graphics.DrawEllipse(left, top, width, height);
    }
}
