using HW2;
using System;

public class Shape : Shapes
{
    public Shape(string shapename) : base(shapename)
    {

    }
    public Shape(string shapename, double x1, double y1, double x2, double y2) : base(shapename, x1, y1, x2, y2)
    {

    }

    //拿到目前這個形狀的名子
    public string GetShapeName()
    {
        return this._shapeName;
    }

    public object GetInfo()
    {
        return $"({x1},{y1}),({x2},{y2})";
    }

    public virtual void Draw(IGraphics graphics)
    {
        throw new NotImplementedException();
    }
    public void SetPoint2(double x,double y)
    {
        this.x2 = x;
        this.y2 = y;
    }
}
