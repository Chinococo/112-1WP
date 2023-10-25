using HW2;
using System;

public class Rectangle : Shape
{
    private const string NAME = "矩形";

    public Rectangle() : base(NAME)
    {
        Random random = new Random();
        x1 = random.Next(196, 484);
        y1 = random.Next(57, 515);
        x2 = random.Next(196, 484);
        y2 = random.Next(57, 515);
    }
    public Rectangle(double x1, double y1, double x2, double y2) : base(NAME,x1,y1,x2,y2)
    {

    }
    public override void Draw(IGraphics graphics)
    {
        double width = Math.Abs(x2 - x1);
        double height = Math.Abs(y2 - y1);
        double left = Math.Min(x1, x2);
        double top = Math.Min(y1, y2);

        graphics.DrawRectangle(left, top, width, height);
    }

}
