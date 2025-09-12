using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Models.Interfaces;
using PovarCRM.Models.Views;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.Viewers.Forms;

namespace PovarCRM.UIcontrollers
{
    public enum MenuMode
    {
        OrderConstructor,
        Picker,
        Additor
    }

    public class MenuController : UpdateObserver, IFormControllerObserver
    {
        public MenuController(UnitOfWork unit, MenuMode mode = MenuMode.Additor, int newOrderId = -1)
        {
            this.Mode = mode;
            this.dataSet = unit;
            this.commandManager = new CommandManagerController();

            if(mode == MenuMode.OrderConstructor)
                this.orderConstructor = new OrderConstructorController(newOrderId, unit, CommandManager);
            
            this.commandManager.AddUpdateMember(orderConstructor);
            orderConstructor.AddUpdateMember(this);
        }

        public void Close(bool CompleteFlag)
        {
            if (!CompleteFlag)
            {
                this.commandManager.DeniedCommands();
            }
            this.ControllerIsClosing?.Invoke();
        }


        public OrderConstructorController OrderConstructor { get { return this.orderConstructor; } }
        public CommandManagerController CommandManager { get { return this.commandManager; } }
        public MenuMode Mode { get; private set; }
        private OrderConstructorController orderConstructor;
        private CommandManagerController commandManager;

        private UnitOfWork dataSet;

        public event CloseController ControllerIsClosing;
    }
}
