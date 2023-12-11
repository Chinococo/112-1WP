using powerpoint; // 引用 HW2 命名空間
using System;

// 定義 Shape 類，繼承自 Shapes 類
public class Shape : Shapes
{
    // 建構函式，初始化 Shape 對象的形狀名稱
    public Shape(string shapename) : base(shapename)
    {
    }

    // 建構函式，初始化 Shape 對象的形狀名稱和座標
    public Shape(string shapename, double x1, double y1, double x2, double y2) : base(shapename, x1, y1, x2, y2)
    {
    }

    // 形狀名稱屬性
    public string shape
    {
        get
        {
            return this._shapeName;
        }
    }

    // 刪除文字屬性
    public string delete
    {
        get
        {
            return "刪除";
        }
    }

    // 資訊文字屬性
    public string information
    {
        get
        {
            return (String)GetInfo();
        }
    }

    // 取得形狀名稱的方法
    public string GetShapeName()
    {
        return this._shapeName;
    }

    // 取得形狀資訊的方法
    public object GetInfo()
    {
        return $"({_x1},{_y1}),({_x2},{_y2})";
    }

    // Draw 方法，等待被覆寫
    public virtual void Draw(IGraphics graphics, bool border = false)
    {
        throw new NotImplementedException();
    }

    // 設定終點座標的方法
    public void SetPoint2(double x, double y)
    {
        this._x2 = x;
        this._y2 = y;
    }

    // 設定起點座標的方法
    public void SetPoint1(double x, double y)
    {
        this._x1 = x;
        this._y1 = y;
    }

    // 取得 X1 座標的方法
    public double GetX1()
    {
        return _x1;
    }

    // 取得 Y1 座標的方法
    public double GetY1()
    {
        return _y1;
    }

    // 取得 X2 座標的方法
    public double GetX2()
    {
        return _x2;
    }

    // 取得 Y2 座標的方法
    public double GetY2()
    {
        return _y2;
    }

    // 移動形狀的方法
    public void Move(double detX, double detY)
    {
        this._x2 += detX;
        this._y2 += detY;
        this._x1 += detX;
        this._y1 += detY;
    }
}
