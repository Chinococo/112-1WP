using HW2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ellipse : Shape
{
    private const string NAME = "橢圓";
    private const int MIN_X = 196;
    private const int MAX_X = 484;
    private const int MIN_Y = 57;
    private const int MAX_Y = 515;
    public Ellipse() : base(NAME)
    {
        Random random = new Random();
        x1 = random.Next(MIN_X, MAX_X);
        y1 = random.Next(MIN_Y, MAX_Y);
        x2 = random.Next(MIN_X, MAX_X);
        y2 = random.Next(MIN_Y, MAX_Y);
    }
    public Ellipse(double x1, double y1, double x2, double y2) : base(NAME, x1, y1, x2, y2)
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
