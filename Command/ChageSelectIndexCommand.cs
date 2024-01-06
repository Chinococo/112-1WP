using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW2.Command
{
    public class ChageSelectIndexCommand : ICommand
    {
        private Model _model;
        int _prevIndex;
        int _nextIndex;
        public ChageSelectIndexCommand(Model model,int prevIndex, int nextIndex)
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
