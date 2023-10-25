using HW2;
using System;

public class Line : Shape
{
    private const string NAME = "線";


    public Line() : base(NAME)
    {
        
    }
    public  override void Draw(IGraphics graphics)
    {
        graphics.DrawLine(x1, y1, x2, y2);
    }
}
