using System.Collections.Generic;

public class Shapes
{
    public string shapename;
    public string info;
	public Shapes(string shapename,string info)
    {
        this.shapename = shapename;
        this.info = info;
    }
}
public class Shape : Shapes{
	public Shape(string shapename, string info) :base(shapename, info)
    {

    }
	public string Getinfo()
    {
        return this.info;
    }
    public string GetShapeName()
    {
        return this.shapename;
    }
}
public class Rectangle : Shape
{
	public Rectangle():base("矩形","(0,0),(50,50)")
    {

    }
}
public class Line : Shape
{
    public Line() : base("線", "(25,25),(50,50)")
    {

    }
}
public class Factory{
    public List<Shapes> data=new List<Shapes>();
	public void AddLine()
    {
        data.Add(new Line());
    }
    public void AddRectangle()
    {
        data.Add(new Rectangle());
    }

}