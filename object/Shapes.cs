public class Shapes
{
    protected string _shapeName;
    protected double _x1;
    protected double _y1;
    protected double _x2;
    protected double _y2;

    public Shapes(string shapeName)
    {
        this._shapeName = shapeName;
    }

    public Shapes(string shapeName, double x1, double y1, double x2, double y2)
    {
        this._shapeName = shapeName;
        this._x1 = x1;
        this._x2 = x2;
        this._y1 = y1;
        this._y2 = y2;
    }
}