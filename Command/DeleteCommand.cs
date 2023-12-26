using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Object
{
    // Represents the drawing state for handling mouse events in a drawing application.
    internal class DeleteCommand : ICommand
    {
        private Model _model;
        Shape _shape;
        DeleteCommand(Model model, Shape shape)
        {
            this._model = model;
            this._shape = shape;
        }
        void ICommand.Excute()
        {
            _model.AddNewLine(_shape);
        }


        void ICommand.Unexcute()
        {
            _model.PopLine();
        }
    }
}
