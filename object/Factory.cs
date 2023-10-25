using System;
using System.Collections.Generic;

public class Factory
{

    public Shape CreateShape(string shapeType)
    {
        switch (shapeType)
        {
            case "Line":
                return new Line();
            case "Rectangle":
                return new Rectangle();
            case "Ellipse":
                return new Ellipse();
            default:
                throw new ArgumentException("Unsupported shape type");
        }
    }
    public Shape CreateShape(string shapeType, double x1, double y1, double x2, double y2)
    {
        switch (shapeType)
        {
            case "Line":
                return new Line(x1,y1,x2,y2);
            case "Rectangle":
                return new Rectangle(x1, y1, x2, y2);
            case "Ellipse":
                return new Ellipse(x1, y1, x2, y2);
            default:
                throw new ArgumentException("Unsupported shape type");
        }
    }
}

