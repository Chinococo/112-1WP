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
    public string shape
    {
        get
        {
            return this._shapeName;
        }
    }
    public string delete
    {
        get
        {
            return "刪除";
        }
    }
    public string information
    {
        get
        {
            return (String) GetInfo();
        }
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
    public virtual void Draw(IGraphics graphics, bool border=false)
    {
        throw new NotImplementedException();
    }

    //設定終點

    public void SetPoint2(double x,double y)
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
    public double GetX1()
    {
        return _x1;
    }

    // Get the Y1 coordinate
    public double GetY1()
    {
        return _y1;
    }

    // Get the X2 coordinate
    public double GetX2()
    {
        return _x2;
    }

    // Get the Y2 coordinate
    public double GetY2()
    {
        return _y2;
    }
    public void Move(double detX,double detY)
    {
        this._x2 += detX;
        this._y2 += detY;
        this._x1 += detX;
        this._y1 += detY;
    }
}
