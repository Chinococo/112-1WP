using System;

public class Factory
{
    private const string ENLINE = "Line";
    private const string ENRECTANGLE = "Rectangle";
    private const string ENELLIPS = "Ellipse";
    private const string ENERROR = "Unsupported shape type";

    //依照參數產出對應型態物件
    public Shape CreateShape(string shapeType)
    {
        switch (shapeType)
        {
            case ENLINE:
                return new Line();

            case ENRECTANGLE:
                return new Rectangle();

            case ENELLIPS:
                return new Ellipse();

            default:
                throw new ArgumentException(ENERROR);
        }
    }

    //依照參數產出對應型態物件

    public Shape CreateShape(string shapeType, double x1, double y1, double x2, double y2)
    {
        switch (shapeType)
        {
            case ENLINE:
                return new Line(x1, y1, x2, y2);

            case ENRECTANGLE:
                return new Rectangle(x1, y1, x2, y2);

            case ENELLIPS:
                return new Ellipse(x1, y1, x2, y2);

            default:
                throw new ArgumentException(ENERROR);
        }
    }
}