using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.UIcontrollers.UImembers
{
    public delegate void CloseController();
    public interface IFormControllerObserver
    {
        public event CloseController ControllerIsClosing;
        protected void Close(bool CompleteFlage);
    }
    public interface IFormControllerMember
    {
        public virtual void SubscribeController(IFormControllerObserver controller)
        {
            controller.ControllerIsClosing += OnFormControllerClose;
        }
        public void OnFormControllerClose();
    }
}
