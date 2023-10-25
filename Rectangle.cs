using System;

public class Rectangle : Shape
{
    private const string NAME = "矩形";
    private string INFO;

    public Rectangle() : base(NAME, GenerateRandomCoordinate())
    {
    }

    private static string GenerateRandomCoordinate()
    {
        Random random = new Random();
        int x1 = random.Next(0, 100); // 生成x座標，這裡假設最大值是100
        int y1 = random.Next(0, 100); // 生成y座標，這裡假設最大值是100
        int x2 = random.Next(x1 + 1, 100); // 生成x座標，確保x2大於x1
        int y2 = random.Next(y1 + 1, 100); // 生成y座標，確保y2大於y1

        return $"({x1},{y1}),({x2},{y2})";
    }
}
