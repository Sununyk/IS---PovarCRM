using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers.UImembers;

namespace PovarCRM.UIcontrollers
{
    public class CommandManagerController : UpdateObserver
    {
        private readonly Stack<ICommand> _undoStack = new();
        private readonly Stack<ICommand> _redoStack = new();

        public void Execute(ICommand command)
        {

            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear(); // очищаем redo при новом действии

            UpdateState();
        }

        public void Undo()
        {
            if (_undoStack.Any())
            {
                var cmd = _undoStack.Pop();
                cmd.Undo();
                _redoStack.Push(cmd);
                
            }
            UpdateState();
        }

        public void Redo()
        {
            if (_redoStack.Any())
            {
                var cmd = _redoStack.Pop();
                cmd.Execute();
                _undoStack.Push(cmd);
            }
            UpdateState();
        }

        public void DeniedCommands()
        {
            while (_undoStack.Count > 0)
            {
                var cmd = _undoStack.Pop();
                cmd.Undo();
            }
        }
    }
}
