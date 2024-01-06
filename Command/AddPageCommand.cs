namespace PowerPoint.Command
{
    internal class AddPageCommand : ICommand
    {
        private Model _model;

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