namespace PowerPoint.Command
{
    // Represents the drawing state for handling mouse events in a drawing application.
    internal class DrawCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public DrawCommand(Model model, Shape shape)
        {
            this._model = model;
            this._shape = shape;
        }

        // 執行以前的指令
        public void Execute()
        {
            _model.AddNewLine(_shape);
            _model.NotifyModelChanged();
        }

        // 還原以前的指令
        public void UndoExecute()
        {
            _model.PopLine();
            _model.NotifyModelChanged();
        }
    }
}