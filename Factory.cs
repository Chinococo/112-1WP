using System.Collections.Generic;

public class Factory
{
    public List<Shapes> data = new List<Shapes>();
    public void AddLine()
    {
        data.Add(new Line());
    }
    public void AddRectangle()
    {
        data.Add(new Rectangle());
    }

}