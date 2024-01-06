using PowerPoint;

namespace HW2.Command
{
    public class ChageSelectIndexCommand : ICommand
    {
        private Model _model;
        private int _prevIndex;
        private int _nextIndex;

        public ChageSelectIndexCommand(Model model, int prevIndex, int nextIndex)
        {
            this._model = model;
            this._prevIndex = prevIndex;
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
            _model.ChangeActivePageIndex(_prevIndex);
        }
    }
}