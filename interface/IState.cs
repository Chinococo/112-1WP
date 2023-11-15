namespace HW2
{
    internal interface IState
    {
        void MouseDown(double x, double y);

        void MouseMove(double x, double y);

        void ReleasedPointer(double x, double y);
    }
}