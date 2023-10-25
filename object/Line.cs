using HW2;
using System;

public class Line : Shape
{
    private const string NAME = "線";


    public Line() : base(NAME)
    {
        Random random = new Random();
        x1 = random.Next(196, 484);
        y1 = random.Next(57, 515);
        x2 = random.Next(196, 484);
        y2 = random.Next(57, 515);
    }
    public  override void Draw(IGraphics graphics)
    {
        graphics.DrawLine(x1, y1, x2, y2);
    }
}
