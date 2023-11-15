using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    interface IState
    {
        void MouseDown(double x, double y);
        void MouseMove(double x, double y);
        void ReleasedPointer(double x, double y);
    }
}
