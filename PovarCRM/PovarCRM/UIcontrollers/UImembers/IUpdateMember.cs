using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers.UImembers
{
    public delegate void UpdateState();
    public interface IUpdateMember
    {
        public void onUpdateState();
    }
}
