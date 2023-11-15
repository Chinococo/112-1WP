using HW2;
using System;

public class Rectangle : Shape
{
    private const string NAME = "矩形";
    private const int MIN_X = 0;
    private const int MAX_X = 300;
    private const int MIN_Y = 0;
    private const int MAX_Y = 300;
    public Rectangle() : base(NAME)
    {
        Random random = new Random();
        _x1 = random.Next(MIN_X, MAX_X);
        _y1 = random.Next(MIN_Y, MAX_Y);
        _x2 = random.Next(MIN_X, MAX_X);
        _y2 = random.Next(MIN_Y, MAX_Y);
    }
    public Rectangle(double x1, double y1, double x2, double y2) : base(NAME,x1,y1,x2,y2)
    {

    }
    //複寫Draw方法
    public override void Draw(IGraphics graphics, bool border)
    {
        double width = Math.Abs(_x2 - _x1);
        double height = Math.Abs(_y2 - _y1);
        double left = Math.Min(_x1, _x2);
        double top = Math.Min(_y1, _y2);
        graphics.DrawRectangle(left, top, width, height);
        if (border)
        {
            graphics.DrawBorder(left, top, width, height);
        }
    }

}
