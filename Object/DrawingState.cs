using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2.Object
{
    class DrawingState : IState
    {
        private Model _model;
        public DrawingState(Model model)
        {
            _model = model;
        }

        public Model Model { get; }

        public void MouseDown(double x, double y)
        {
            this._model.PressPointerDrawing(x, y);
        }

        public void MouseMove(double x, double y)
        {
            this._model.MovedPointerDrawing(x, y);
        }
        public void ReleasedPointer(double x, double y)
        {
            this._model.ReleasedPointerDrawing(x, y);
        }
    }
}
