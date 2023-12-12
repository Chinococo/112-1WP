using System;

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

    public Shape CreateShape(string shapeType, double x1, double y1, double x2, double y2)
    {
        switch (shapeType)
        {
            case NAME_LINE:
                return new Line(x1, y1, x2, y2);

            case NAME_RECTANGLE:
                return new Rectangle(x1, y1, x2, y2);

            case NAME_ELLIPSE:
                return new Ellipse(x1, y1, x2, y2);

            default:
                throw new ArgumentException(NAME_ERROR);
        }
    }
}