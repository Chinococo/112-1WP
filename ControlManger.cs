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
        public ControlManger()
        {
            _command = new List<ICommand>();
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
        public ICommand Excute()
        {
            _excuteIndex += 1;
            return _command[_excuteIndex - 1];


        }
        public ICommand UndoExcute()
        {
            _excuteIndex -= 1;
            if (_excuteIndex+1 == _command.Count)
            {
                return _command[_excuteIndex];
            }
            else
            {
                return _command[_excuteIndex+1];
            }
            
            
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
