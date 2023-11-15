using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Object
{
    class PointState : IState
    {
        private Model _model;

        public PointState(Model model)
        {
            this._model = model;
        }

        public void MouseDown(double x, double y)
        {
            this._model.PressPointerPoint(x, y);
        }

        public void MouseMove(double x, double y)
        {
            this._model.MovedPointerPoint(x, y);
        }
        public void ReleasedPointer(double x, double y)
        {
            this._model.ReleasedPointerPoint(x, y);
        }
    }
}
