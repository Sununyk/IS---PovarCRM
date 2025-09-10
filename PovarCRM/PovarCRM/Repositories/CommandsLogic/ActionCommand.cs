using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Repositories.CommandsLogic
{
    public class ActionCommand<T>: ICommand where T : class, ICloneable, ICopyable<T>
    {
        Action actionDo;
        Action actionUndo;
        T? oldState;
        public ActionCommand(Action funcDo, Action funcUndo, T oldStat = null)
        {
            this.oldState = oldStat;
            this.actionDo = funcDo ?? throw new ArgumentNullException(nameof(funcDo));
            this.actionUndo = funcUndo ?? throw new ArgumentNullException(nameof(funcUndo));
        }

        public void Execute()
        {
            this.actionDo();
        }

        public void Undo()
        {
            this.actionUndo();
        }
    }
}
