using System.ComponentModel;

namespace Dialog
{
    public class UndoResult
    {
        public BindingList<Shape> PageShape
        {
            get; set;
        }

        public int PageIndex
        {
            get; set;
        }

        public System.Drawing.Size PageSize
        {
            get; set;
        }
    }
}