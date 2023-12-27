using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Object
{
    // Represents the drawing state for handling mouse events in a drawing application.
    internal class MoveCommand : ICommand
    {
        private Model _model;
        Shape _prev,_next;
        int _index;
        public MoveCommand(Model model, Shape prev, Shape next, int index)
        {
            this._model = model;
            this._prev = prev;
            this._next = next;
            this._index = index;
        }
        public void Excute()
        {
            _model.MoveByIndex(_index,_next);
        }


        public void Unexcute()
        {
            _model.MoveByIndex(_index, _prev);
        }
    }
}
