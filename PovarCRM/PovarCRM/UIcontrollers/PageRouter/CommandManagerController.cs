using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PovarCRM.UIcontrollers.PageRouter
{
    public class CommandManagerController
    {
        private readonly Stack<ICommand> _undoStack = new();
        private readonly Stack<ICommand> _redoStack = new();

        public void Execute(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // очищаем redo при новом действии
        }

        public void Undo()
        {
            if (_undoStack.Any())
            {
                var cmd = _undoStack.Pop();
                cmd.Undo();
                _redoStack.Push(cmd);
            }
        }

        public void Redo()
        {
            if (_redoStack.Any())
            {
                var cmd = _redoStack.Pop();
                cmd.Execute();
                _undoStack.Push(cmd);
            }
        }
    }
}
