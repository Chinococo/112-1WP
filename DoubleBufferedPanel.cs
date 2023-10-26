namespace HW2
{
    using System.Windows.Forms;

    namespace DrawingForm
    {
        internal class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                DoubleBuffered = true;
            }
        }
    }
}