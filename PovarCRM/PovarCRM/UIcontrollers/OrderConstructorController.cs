using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Models.Views;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;
using static PovarCRM.Repositories.DataExctractor;

namespace PovarCRM.UIcontrollers
{

    public class OrderConstructorController : UpdateObserver
    {


        public OrderConstructorController(int newOrderId, UnitOfWork unit, CommandManagerController commandController)
        {
            this.newOrderCheck = unit.OrderChecks.GetByID(newOrderId);
            this.unit = unit;
            this.commandManagerController = commandController;

            dishTypes = new BindingListEx<DishType>();
            dishRecipeViews = new BindingListEx<DishRecipeView>();
            dishViews = new BindingListEx<DishView>();


            dishTypes.AppendList(GetDishTypes(unit));
            dishViews.AppendList(GetDishViews(unit));

            dishViews.ListItemChanged += OnListItemChanged;

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
            if(eventPack.GetPackageSize() > 0)
                this.commandManagerController.Execute(eventPack);

        }

        public void UpdateDishRecipe(int dishId)
        {
            dishRecipeViews.Clear();
            dishRecipeViews.AppendList(GetDishRecipeViews(dishId, unit));
        }

        public void onUpdateState()
        {
           // UpdateDishView();
        }
        public void UpdateDishView()
        {
            dishViews.Clear();
            dishViews.AppendList(GetDishViews(unit));
        }



        private BindingListEx<DishType> dishTypes;
        private BindingListEx<DishView> dishViews;
        private BindingListEx<DishRecipeView> dishRecipeViews;
       

        private CommandManagerController commandManagerController;
        private UnitOfWork unit;
        private OrderCheck newOrderCheck;

    }

}
