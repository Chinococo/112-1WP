using System.Collections.Generic;

public class Shapes
{
    protected string _shapeName;
    protected double x1;
    protected double y1;
    protected double x2;
    protected double y2;

    public Shapes(string shapename)
    {
        this._shapeName = shapename;
    }

    public Shapes(string shapename, double x1, double y1, double x2, double y2)
    {
        this._shapeName = shapename;
        this.x1 = x1;
        this.x2 = x2;
        this.y1 = y1;
        this.y2 = y2;
    }
}


