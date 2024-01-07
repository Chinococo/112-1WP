using HW2.Command;
using PowerPoint.Command;
using PowerPoint.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    public class ControlManger
    {
        private List<ICommand> _command;
        private int _excuteIndex = 0;

        public ControlManger()
        {
            _command = new List<ICommand>();
        }

        public void AddCommand(Model model, Shape shape)
        {
            UpdateExecuteId();
            _command.Add(new AddCommand(model, shape.Clone()));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void DeleteCommand(Model model, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(model, shape.Clone(), index));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void DeleteCommand(Model model, BindingList<Shape> list, int index, Size pageSize)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(model, list, index, pageSize));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void ResizeCommand(Model model, Shape previous, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new ResizeCommand(model, previous, shape.Clone(), index));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void MoveCommand(Model model, Shape previous, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new MoveCommand(model, previous, shape.Clone(), index));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void DrawCommand(Model model, Shape shape)
        {
            UpdateExecuteId();
            _command.Add(new DrawCommand(model, shape.Clone()));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void PageCommand(Model model)
        {
            UpdateExecuteId();
            _command.Add(new AddPageCommand(model));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void ChageSelectIndexCommand(Model model, int prev, int next)
        {
            UpdateExecuteId();
            _command.Add(new ChageSelectIndexCommand(model, prev, next));
            _excuteIndex += 1;
            ShowCommand();
        }

        public void ShowCommand()
        {
            Console.WriteLine("現在狀態");
            for (int i = 0; i < _command.Count; i++)
                Console.WriteLine(_command[i]);
        }

        public ICommand Excute()
        {
            _excuteIndex += 1;
            return _command[_excuteIndex - 1];
        }

        public ICommand UndoExcute()
        {
            _excuteIndex -= 1;
            if (_excuteIndex + 1 == _command.Count)
            {
                return _command[_excuteIndex];
            }
            else
            {
                return _command[_excuteIndex];
            }
        }

        public void UpdateExecuteId()
        {
            while (_command.Count != _excuteIndex)
            {
                _command.RemoveAt(_command.Count - 1);
            }
        }

        public bool UndoButtonStatus()
        {
            return _excuteIndex != 0;
        }

        public bool RedoButtonStatus()
        {
            return _excuteIndex < _command.Count;
        }
    }
}