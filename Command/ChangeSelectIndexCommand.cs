using PowerPoint;

namespace Dialog.Command
{
    public class ChangeSelectIndexCommand : ICommand
    {
        private Model _model;
        private int _previousIndex;
        private int _nextIndex;

        public ChangeSelectIndexCommand(Model model, int previousIndex, int nextIndex)
        {
            this._model = model;
            this._previousIndex = previousIndex;
            this._nextIndex = nextIndex;
        }

        // 執行以前的指令
        public void Execute()
        {
            _model.ChangeActivePageIndex(_nextIndex);
        }

        // 還原成以前的指令
        public void UndoExecute()
        {
            _model.ChangeActivePageIndex(_previousIndex);
        }
    }
}