namespace PowerPoint
{
    public interface ICommand
    {
        //執行
        void Execute();

        //回復
        void UndoExecute();
    }
}