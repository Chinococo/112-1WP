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

    //回傳資訊

    public object GetInfo()
    {
        return $"({_x1},{_y1}),({_x2},{_y2})";
    }

    //Draw方法 等待覆蓋
    public virtual void Draw(IGraphics graphics)
    {
        throw new NotImplementedException();
    }

    //設定終點

    public void SetPoint2(double x, double y)
    {
        this._x2 = x;
        this._y2 = y;
    }

    //設定起點

    public void SetPoint1(double x, double y)
    {
        this._x1 = x;
        this._y1 = y;
    }
}