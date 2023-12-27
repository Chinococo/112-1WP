using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Command
{
    // Represents the drawing state for handling mouse events in a drawing application.
    internal class DrawCommand : ICommand
    {
        private Model _model;
        Shape _shape;
        public DrawCommand(Model model, Shape shape)
        {
            this._model = model;
            this._shape = shape;
        }
        public void Excute()
        {
            _model.AddNewLine(_shape);
        }


        public void Unexcute()
        {
            _model.PopLine();
        }
    }
}
