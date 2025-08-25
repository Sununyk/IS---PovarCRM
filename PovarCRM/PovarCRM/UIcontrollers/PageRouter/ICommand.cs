using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers.PageRouter
{

    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    public delegate void onCommandExec(object sender, ICommand e);
}
