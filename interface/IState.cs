using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    interface IState
    {
        void MouseDown(int x, int y);
        void MouseMove(int x, int y);
    }
}
