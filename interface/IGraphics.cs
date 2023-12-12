namespace PowerPoint
{
    public interface IGraphics
    {
        //清除整個畫面
        void ClearAll();

        //畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        //畫矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //畫圓形
        void DrawEllipse(double x1, double y1, double x2, double y2);

        //畫線
        void DrawBorder(double x1, double y1, double x2, double y2);
    }
}