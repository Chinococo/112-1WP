public class Shape : Shapes
{
    public Shape(string shapename, string info) : base(shapename, info)
    {

    }

    //拿到目前這個形狀的資訊
    public string GetInfo()
    {
        return this._info;
    }

    //拿到目前這個形狀的名子
    public string GetShapeName()
    {
        return this._shapeName;
    }
}
