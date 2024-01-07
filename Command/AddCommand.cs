namespace PowerPoint.Command
{
    // Represents the drawing state for handling mouse events in a drawing application.
    public class AddCommand : ICommand
    {
        private Model _model;
        private Shape _shape;

        public AddCommand(Model model, Shape shape)
        {
            this._model = model;
            this._shape = shape;
        }

        //重現
        public void Execute()
        {
            _model.AddNewLine(_shape);
            _model.NotifyModelChanged();
        }

        //還原
        public void UndoExecute()
        {
            _model.PopLine();
            _model.NotifyModelChanged();
        }
    }
}