using PowerPoint;
using System;

public class Ellipse : Shape
{
    private const string NAME = "橢圓";
    private const int MIN_X = 0;
    private const int MAX_X = 300;
    private const int MIN_Y = 0;
    private const int MAX_Y = 300;

    public Ellipse() : base(NAME)
    {
        Random random = new Random();
        _x1 = random.Next(MIN_X, MAX_X);
        _y1 = random.Next(MIN_Y, MAX_Y);
        _x2 = random.Next(MIN_X, MAX_X);
        _y2 = random.Next(MIN_Y, MAX_Y);
    }

    public Ellipse(double x1, double y1, double x2, double y2) : base(NAME, x1, y1, x2, y2)
    {
    }

    //複寫Draw方法
    public override void Draw(CustomGraphics graphics, bool border)
    {
        graphics.DrawEllipse(_x1, _y1, _x2, _y2);
        if (border)
        {
            graphics.DrawBorder(_x1, _y1, _x2, _y2);
        }
    }
}