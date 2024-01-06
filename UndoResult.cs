using System.ComponentModel;

namespace HW2
{
    public class UndoResult
    {
        public BindingList<Shape> PageShape { get; set; }
        public int PageIndex { get; set; }
        public System.Drawing.Size PageSize { get; set; }
    }
}