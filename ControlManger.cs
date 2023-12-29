using PowerPoint.Command;
using PowerPoint.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class ControlManger
    {
        private List<ICommand> _command;
        int _excuteIndex = 0;
        Model _model;
        public ControlManger(Model model)
        {
            _command = new List<ICommand>();
            this._model = model;
        }
        public void AddCommand(Model model,Shape shape)
        {
            UpdateExecuteId();
            _command.Add(new AddCommand(model, shape.Clone()));
            _excuteIndex += 1;
        }
        public void DeleteCommand(Model model, Shape shape,int index)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(model, shape.Clone(),index));
            _excuteIndex += 1;
        }
        public void ResizeCommand(Model model, Shape previous,Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new ResizeCommand(model,previous, shape.Clone(), index));
            _excuteIndex += 1;
        }
        public void MoveCommand(Model model, Shape previous, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new MoveCommand(model, previous, shape.Clone(), index));
            _excuteIndex += 1;
        }
        public void DrawCommand(Model model, Shape shape)
        {
            UpdateExecuteId();
            _command.Add(new DrawCommand(model, shape));
            _excuteIndex += 1;
        }
        public void Excute()
        {
            _command[_excuteIndex].Execute();
            _excuteIndex += 1;
            _model.NotifyModelChanged();
        }
        public void UndoExcute()
        {
            _command[_excuteIndex].UndoExecute();
            _excuteIndex -= 1;
            _model.NotifyModelChanged();
        }
        public void UpdateExecuteId()
        {
            while (_command.Count  != _excuteIndex)
            {
                _command.RemoveAt(_command.Count - 1);
            }
        }
    }
}
