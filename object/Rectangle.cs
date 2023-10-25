﻿using HW2;
using System;

public class Rectangle : Shape
{
    private const string NAME = "矩形";

    public Rectangle() : base(NAME)
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