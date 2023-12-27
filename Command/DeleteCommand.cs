using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Object
{
    // Represents the drawing state for handling mouse events in a drawing application.
    public  class DeleteCommand : ICommand
    {
        private Model _model;
        Shape _shape;
        int _index;
        public DeleteCommand(Model model, Shape shape,int index)
        {
            this._model = model;
            this._shape = shape;
            this._index = index;
        }
        public void Excute()
        {
            _model.DeleteLineByIndex(_index);
        }


        public void Unexcute()
        {
            _model.InserByIndex(_index, _shape);
        }
    }
}
