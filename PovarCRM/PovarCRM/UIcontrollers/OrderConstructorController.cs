using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.Repositories;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;
using static PovarCRM.Repositories.DataExtractor;

namespace PovarCRM.UIcontrollers
{

    public class OrderConstructorController : UpdateObserver
    {


        public OrderConstructorController(UnitOfWork unit, int newOrderId, CommandManagerController commandController)
        {

            this.unit = unit;
            this.newOrderCheck = unit.OrderChecks.GetByID(newOrderId);
            if (newOrderCheck == null)
                throw new Exception();

            this.commandManagerController = commandController;

            dishTypes = new BindingListEx<DishType>();
            dishRecipeViews = new BindingListEx<DishRecipeView>();
            dishViews = new BindingListEx<DishView>();


            dishTypes.AppendList(GetDishTypes(unit));
            dishViews.AppendList(GetDishViews(unit));

            dishViews.AddUpdateMember(this);
            dishViews.ListItemChanged += OnListItemChanged;
            dishViews.CommandReadyToExec += (object obj, ICommand command) =>
            {
                commandController.Execute(command);
            };
            dishTypes.CommandReadyToExec += (object obj, ICommand command) =>
            {
                commandController.Execute(command);
            };
    
        }
        public BindingListEx<DishType> InitDishTypes()
        {
            return dishTypes;
        }
        public BindingListEx<DishView> InitDishViews()
        {
            return dishViews;
        }
        public BindingListEx<DishRecipeView> InitDishRecipeViews()
        {
            return dishRecipeViews;
        }
        public void OnListItemChanged(object sender, DishView oldItem, DishView newItem, ICommand changeOldOnNewItemCommand)
        {
            Item newOrderItem = new Item
            {
                DishId = newItem.Id,
                OrderCheckId = this.newOrderCheck.Id,
                DishCount = newItem.Count
            };
            CommandPackage eventPack = new CommandPackage();

            eventPack.AddCommand(new ActionCommand<OrderCheck>(() => DataExtractor.UpdateExistOrderCheckParam(newOrderCheck.Id, unit), () => DataExtractor.UpdateExistOrderCheckParam(newOrderCheck.Id, unit)));
            eventPack.AddCommand(changeOldOnNewItemCommand);

            if (oldItem.Picked != newItem.Picked)
            {
                if (newItem.Picked == false)
                {
                    //удаляем блюдо из заказа
                    eventPack.AddCommand(new DeleteFromRep<Item>(
                        unit, newOrderItem));
                }
                else
                {
                    //добавляем блюдо в заказ count + 1 and блокируем биндинглист
                    newItem.Count = 1;
                    eventPack.AddCommand(new AddToRep<Item>(
                        unit, newOrderItem));
                    newOrderItem.DishCount = 1;
                    eventPack.AddCommand(new UpdateInRep<Item>(
                        unit, newOrderItem));
                }
            }
            if (oldItem.Count != newItem.Count && newItem.Picked == true)
            {

                //добавляем блюдо в заказ
                eventPack.AddCommand(new UpdateInRep<Item>(
                    unit, newOrderItem));
                
            }
            eventPack.AddCommand(new ActionCommand<OrderCheck>(() => DataExtractor.UpdateExistOrderCheckParam(newOrderCheck.Id, unit), () => DataExtractor.UpdateExistOrderCheckParam(newOrderCheck.Id, unit)));
            if (eventPack.GetPackageSize() > 0)
                this.commandManagerController.Execute(eventPack);

        }

        public void UpdateDishRecipe(int dishId)
        {
            dishRecipeViews.Clear();
            dishRecipeViews.AppendList(GetDishRecipeViews(dishId, unit));
        }

        public void UpdateDishView()
        {
            dishViews.Clear();
            dishViews.AppendList(GetDishViews(unit));
        }


        public int NewOrderCheck { get {return this.newOrderCheck.Id; } }
        private BindingListEx<DishType> dishTypes;
        private BindingListEx<DishView> dishViews;
        private BindingListEx<DishRecipeView> dishRecipeViews;
       

        private CommandManagerController commandManagerController;
        private UnitOfWork unit;
        private OrderCheck newOrderCheck;

        public event UpdateState ObserverStateUpdated;
    }

}
