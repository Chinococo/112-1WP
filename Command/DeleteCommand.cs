namespace PowerPoint.Object
{
    // Represents the drawing state for handling mouse events in a drawing application.
    public class DeleteCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private int _index;

        public DeleteCommand(Model model, Shape shape, int index)
        {
            this._model = model;
            this._shape = shape;
            this._index = index;
        }

        // 執行以前的指令
        public void Execute()
        {
            _model.DeleteLineByIndex(_index);
        }

        // 還原成以前的指令
        public void UndoExecute()
        {
            _model.InsertByIndex(_index, _shape);
        }
    }
}