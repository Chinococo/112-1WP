public class Shape : Shapes
{
    public Shape(string shapename, string info) : base(shapename, info)
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
