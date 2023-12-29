using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Command
{
    class AddPageCommand : ICommand
    {
        Model _model;
        public AddPageCommand(Model model)
        {
            _model = model;
        }
        // 執行以前的指令
        public void Execute()
        {
            _model.AddNewPage();
        }

        // 還原成以前的指令
        public void UndoExecute()
        {
            _model.DeleteNewPage();
        }
    }
}
