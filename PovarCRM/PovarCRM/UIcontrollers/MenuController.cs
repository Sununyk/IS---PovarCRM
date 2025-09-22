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
            this.tempContext = unit;
            this.commandManager = new CommandManagerController();

            if(mode == MenuMode.OrderConstructor)
                this.orderConstructor = new OrderConstructorController(unit, newOrderId,  CommandManager);
            
            this.commandManager.AddUpdateMember(orderConstructor);
            orderConstructor.AddUpdateMember(this);
        }

        public void Close(bool CompleteFlag)
        {
            if (!CompleteFlag)
            {
                this.commandManager.DeniedCommands();
            }
            else
            {
                //using (var unit = new UnitOfWork())
                //{
                //    unit.Items.AddRange(tempContext.Items.GetCollection().ToArray<Item>());
                //}
                this.OrderComplete = true;
            }
            this.ControllerIsClosing?.Invoke();

        }
        public UnitOfWork TempContext { get { return tempContext; } private set { tempContext = value; } }


        public OrderConstructorController OrderConstructor { get { return this.orderConstructor; } }
        public CommandManagerController CommandManager { get { return this.commandManager; } }
        public MenuMode Mode { get; private set; }
        private OrderConstructorController orderConstructor;
        private CommandManagerController commandManager;

        private UnitOfWork tempContext;

        public bool OrderComplete = false;
        public event CloseController ControllerIsClosing;
    }
}
