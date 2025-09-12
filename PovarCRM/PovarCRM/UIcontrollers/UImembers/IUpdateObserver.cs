using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers.UImembers
{
    public interface IUpdateObserver : IUpdateMember
    {
        public event UpdateState ObserverStateUpdated;

        public void UpdateState();
        public void AddUpdateMember(IUpdateMember member);
    }
}
