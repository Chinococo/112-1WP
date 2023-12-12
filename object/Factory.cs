using System;
using System.Drawing;

public class Factory
{
    private const string NAME_LINE = "Line";
    private const string NAME_RECTANGLE = "Rectangle";
    private const string NAME_ELLIPSE = "Ellipse";
    private const string NAME_ERROR = "Unsupported shape type";

    //依照參數產出對應型態物件
    public Shape CreateShape(string shapeType)
    {
        switch (shapeType)
        {
            case NAME_LINE:
                return new Line();

            case NAME_RECTANGLE:
                return new Rectangle();

            case NAME_ELLIPSE:
                return new Ellipse();

            default:
                throw new ArgumentException(NAME_ERROR);
        }
    }

    //依照參數產出對應型態物件

    public Shape CreateShape(string shapeType, Point startPoint, Point endPoint)
    {
        switch (shapeType)
        {
            case NAME_LINE:
                return new Line(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            case NAME_RECTANGLE:
                return new Rectangle(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            case NAME_ELLIPSE:
                return new Ellipse(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y);

            default:
                throw new ArgumentException(NAME_ERROR);
        }
    }
}