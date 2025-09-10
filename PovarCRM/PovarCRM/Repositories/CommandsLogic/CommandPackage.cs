using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.Repositories.CommandsLogic
{
    public class CommandPackage : ICommand
    {
        private bool executedFlag = false;
        private List<ICommand> package = new List<ICommand>();
        private List<ICommand> executed = new List<ICommand>();
        public CommandPackage() { }
        public CommandPackage(params ICommand[] commands)
        {
            if (commands == null || commands.Length == 0)
                throw new ArgumentNullException();
            package.AddRange(commands);
        }
        public int GetPackageSize()
        {
            return this.package.Count();
        }
        public void AddCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException();
            if (executedFlag) // защита от добавления команды в уже выполненный пакет
                throw new InvalidOperationException("Cannot add command to already executed package");
            package.Add(command);
        }

        public void Execute()
        {
            if(executedFlag) // защита от повторного выполнения
                throw new InvalidOperationException("Command package already executed");
            //реализация атомарного выполнения пакета команд
            try
            {
                foreach (var cmd in package)
                {
                    cmd.Execute();
                    executed.Add(cmd);
                }
                this.executedFlag = true;
            }
            catch
            {
                Undo();
                throw; // пробрасываем исключение выше
            }
        }

        public void Undo()
        {
            // если произошла ошибка, откатываем то, что успели выполнить
            foreach (var cmd in Enumerable.Reverse(executed))
            {
                cmd.Undo();
            }
            executed.Clear();

            this.executedFlag = false;
        }
    }
}
