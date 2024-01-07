using Dialog.Command;
using PowerPoint.Command;
using PowerPoint.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint
{
    public class ControlManager
    {
        private List<ICommand> _command;
        private int _executeIndex = 0;
        private const string NOW_STATUS = "現在狀態";
        public ControlManager()
        {
            _command = new List<ICommand>();
        }

        public void AddCommand(Model model, Shape shape)
        {
            UpdateExecuteId();
            _command.Add(new AddCommand(model, shape.Clone()));
            _executeIndex += 1;
            ShowCommand();
        }

        public void DeleteCommand(Model model, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(model, shape.Clone(), index));
            _executeIndex += 1;
            ShowCommand();
        }

        public void DeleteCommand(Model model, BindingList<Shape> list, int index, Size pageSize)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(model, list, index, pageSize));
            _executeIndex += 1;
            ShowCommand();
        }

        public void ResizeCommand(Model model, Shape previous, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new ResizeCommand(model, previous, shape.Clone(), index));
            _executeIndex += 1;
            ShowCommand();
        }

        public void MoveCommand(Model model, Shape previous, Shape shape, int index)
        {
            UpdateExecuteId();
            _command.Add(new MoveCommand(model, previous, shape.Clone(), index));
            _executeIndex += 1;
            ShowCommand();
        }

        public void DrawCommand(Model model, Shape shape)
        {
            UpdateExecuteId();
            _command.Add(new DrawCommand(model, shape.Clone()));
            _executeIndex += 1;
            ShowCommand();
        }

        public void PageCommand(Model model)
        {
            UpdateExecuteId();
            _command.Add(new AddPageCommand(model));
            _executeIndex += 1;
            ShowCommand();
        }

        public void ChangeSelectIndexCommand(Model model, int previous, int next)
        {
            UpdateExecuteId();
            _command.Add(new ChangeSelectIndexCommand(model, previous, next));
            _executeIndex += 1;
            ShowCommand();
        }

        public void ShowCommand()
        {
            Console.WriteLine(NOW_STATUS);
            for (int i = 0; i < _command.Count; i++)
                Console.WriteLine(_command[i]);
        }

        public ICommand Execute()
        {
            _executeIndex += 1;
            return _command[_executeIndex - 1];
        }

        public ICommand UndoExecute()
        {
            _executeIndex -= 1;
            if (_executeIndex + 1 == _command.Count)
            {
                return _command[_executeIndex];
            }
            else
            {
                return _command[_executeIndex];
            }
        }

        public void UpdateExecuteId()
        {
            while (_command.Count != _executeIndex)
            {
                _command.RemoveAt(_command.Count - 1);
            }
        }

        public bool IsUndoButtonStatus()
        {
            return _executeIndex != 0;
        }

        public bool IsRedoButtonStatus()
        {
            return _executeIndex < _command.Count;
        }
    }
}