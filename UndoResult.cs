using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class UndoResult
    {
        public BindingList<Shape> PageShape { get; set; }
        public int PageIndex { get; set; }
        public System.Drawing.Size PageSize { get; set; }
    }
}
