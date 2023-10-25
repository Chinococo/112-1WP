using System.Collections.Generic;

public class Factory
{
    private List<Shapes> _data = new List<Shapes>();

    //新增一個線
    public void AddLine()
    {
        _data.Add(new Line());
    }

    //新增一個正方形
    public void AddRectangle()
    {
        _data.Add(new Rectangle());
    }

}