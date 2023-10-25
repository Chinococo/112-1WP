using System;

public class Line : Shape
{
    private const string NAME = "線";
    private string INFO;

    public Line() : base(NAME, GenerateRandomCoordinates())
    {

    }

    private static string GenerateRandomCoordinates()
    {
        Random random = new Random();
        int x1 = random.Next(0, 100);  // 0 到 100 之间的随机 x 坐标
        int y1 = random.Next(0, 100);  // 0 到 100 之间的随机 y 坐标
        int x2 = random.Next(0, 100);  // 0 到 100 之间的随机 x 坐标
        int y2 = random.Next(0, 100);  // 0 到 100 之间的随机 y 坐标

        // 将坐标格式化为字符串
        return $"({x1},{y1}),({x2},{y2})";
    }
}
