namespace PowerPoint.Object
{
    // Represents the drawing state for handling mouse events in a drawing application.
    internal class ResizeCommand : ICommand
    {
        private Model _model;
        private Shape _previous;
        private Shape _next;
        private int _index;

        public ResizeCommand(Model model, Shape previous, Shape next, int index)
        {
            this._model = model;
            this._previous = previous;
            this._next = next;
            this._index = index;
        }

        //執行以前的指令
        public void Execute()
        {
            _model.MondifyByIndex(_index, _next);
        }

        //還原以前的指令
        public void UndoExecute()
        {
            _model.MondifyByIndex(_index, _previous);
        }
    }
}