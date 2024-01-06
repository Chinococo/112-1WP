using System.ComponentModel;

namespace PowerPoint.Command
{
    // Represents the drawing state for handling mouse events in a drawing application.
    public class DeleteCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private int _index;
        private BindingList<Shape> _list;
        public DeleteCommand(Model model, Shape shape, int index)
        {
            this._model = model;
            this._shape = shape;
            this._index = index;
        }
        public DeleteCommand(Model model, BindingList<Shape> list, int index)
        {
            this._model = model;
            this._list = list;
            this._index = index;
        }
        // 執行以前的指令
        public void Execute()
        {
            if (_list != null)
                _model.DeleteLineByIndex(_index);
            else
                _model.DeletePageByIndex(_index);
        }

        // 還原成以前的指令
        public void UndoExecute()
        {
            if (_list != null)
                _model.InsertPageByIndex(_list, _index);
            else
                _model.InsertByIndex(_index, _shape);
        }
    }
}