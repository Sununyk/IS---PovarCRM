using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace PovarCRM.UIcontrollers.UImembers
{
    public abstract class UpdateObserver : IUpdateObserver, IUpdateMember
    {
        public event UpdateState ObserverStateUpdated;

        public void UpdateState()
        {
            ObserverStateUpdated?.Invoke();
        }

        public void AddUpdateMember(IUpdateMember member)
        {
            ObserverStateUpdated += member.onUpdateState;
        }
        public void AddMembersByDelegate(UpdateState del)
        {
            ObserverStateUpdated += del;
        }

        public void onUpdateState()
        {
            UpdateState();
        }
    }
}
