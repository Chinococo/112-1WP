namespace powerpoint
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