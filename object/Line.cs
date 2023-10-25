using HW2;
using System;

public class Line : Shape
{
    private const string NAME = "線";
    private const int MIN_X = 196;
    private const int MAX_X = 484;
    private const int MIN_Y = 57;
    private const int MAX_Y = 515;

    public Line() : base(NAME)
    {
        Random random = new Random();
        x1 = random.Next(MIN_X, MAX_X);
        y1 = random.Next(MIN_Y, MAX_Y);
        x2 = random.Next(MIN_X, MAX_X);
        y2 = random.Next(MIN_Y, MAX_Y);
    }
    public Line(double x1, double y1, double x2, double y2) : base(NAME, x1, y1, x2, y2)
    {

    }
    public override void Draw(IGraphics graphics)
    {
        graphics.DrawLine(x1, y1, x2, y2);
    }
}
