using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using System.Windows.Forms;
using PovarCRM.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using PovarCRM.UIcontrollers.UImembers;
using PovarCRM.UIelements;
using static PovarCRM.Repositories.DataExctractor;
using PovarCRM.Repositories.CommandsLogic;

namespace PovarCRM.UIcontrollers
{
    public class ServingOrdersController : IUpdateMember
    {
        private int selectedOrderId = -1;

        UnitOfWork dataSet;

        private List<int> newOrdersId;
        private BindingListEx<OrderCheck> orders;
        private BindingListEx<ItemView> items;
        BindingListEx<OrderCheckRecipeView> orderRecipeViews;
        public ServingOrdersController()
        {
            this.dataSet = new UnitOfWork(PovarDbContext.DbMode.DataBaseOff);
            using(var unit = new UnitOfWork())
            {
                unit.InitRepositoryes();
                this.dataSet.AddReps(unit);
            }


            orders = new BindingListEx<OrderCheck>();
            items = new BindingListEx<ItemView>();
            orderRecipeViews = new BindingListEx<Models.Views.OrderCheckRecipeView>();

            newOrdersId = new List<int>();
            //this.onUpdateState();
        }

        public void onSelectedOrderId(int orderId)
        {
            UpdateItemsAndIngredients(orderId);
        }
        public void UpdateItemsAndIngredients(int orderCheckId)
        {
            if (orderCheckId == this.selectedOrderId)
                return;

            items.Clear();
            items.AppendList(GetViewItemsOfOrder(orderCheckId, dataSet));
            orderRecipeViews.Clear();
            orderRecipeViews.AppendList(GetRecipeOfOrder(orderCheckId, dataSet));

            this.selectedOrderId = orderCheckId;
        }
        public void onUpdateState()
        {
           
            orders.Clear();
            orders.AppendList(GetOrdersSortedByTime());

            if (selectedOrderId < 0)
                return;

            items.Clear();
            items.AppendList(GetViewItemsOfOrder(selectedOrderId, dataSet));
            orderRecipeViews.Clear();
            orderRecipeViews.AppendList(GetRecipeOfOrder(selectedOrderId, dataSet));
        }

        public BindingListEx<ItemView> initItemViewList()
        { 
            return items;
        }
        public BindingListEx<OrderCheck> initOrderCheckList()
        {
            //сразу заполняем для визуала

            orders.Clear();
            orders.AppendList(dataSet.OrderChecks.GetCollection().ToList());
  
            return orders;
        }
        public BindingListEx<OrderCheckRecipeView> initRecipeViewList()
        {
            return orderRecipeViews;
        }

        public int CreatOrderCheck(String clientNaming)
        {
            OrderCheck newOrder;
            using (var unit = new UnitOfWork())
            {
                newOrder = (new OrderCheck
                {
                    ClientName = clientNaming,
                    Total = 0,
                    OrderTime = DateTime.Now,
                });
                unit.OrderChecks.Add(newOrder);
                unit.Save();

                this.newOrdersId.Add(newOrder.Id);
                this.dataSet.OrderChecks.Add(newOrder);
            }


            return newOrder.Id;
        }

        public UnitOfWork GetUnitOfWork()
        {
            return this.dataSet;
        }
    //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    //{
    //    if (e.RowIndex >= 0)
    //    {
    //        // Получаем выбранную строку
    //        DataGridViewRow row = _ordersTable.Rows[e.RowIndex];
    //        _itemsAndProductsTable.DataSource = GetViewItemsByOrder((row.DataBoundItem as OrderCheck).Id);
    //    }
    //    return;
    //}


    }
}
