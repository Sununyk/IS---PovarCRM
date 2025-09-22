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
using static PovarCRM.Repositories.DataExtractor;
using PovarCRM.Repositories.CommandsLogic;
using PovarCRM.Repositories;

namespace PovarCRM.UIcontrollers
{
    public class ServingOrdersController : IUpdateObserver
    {
        private int selectedOrderId = -1;

        UnitOfWork unit;

        private int newOrderId;
        private BindingListEx<OrderCheck> orders;
        private BindingListEx<ItemView> items;
        BindingListEx<OrderCheckRecipeView> orderRecipeViews;

        public event UpdateState ObserverStateUpdated;

        public ServingOrdersController()
        {
            this.unit = new UnitOfWork();
            //LoadDataSet();

            orders = new BindingListEx<OrderCheck>();
            items = new BindingListEx<ItemView>();
            orderRecipeViews = new BindingListEx<Models.Views.OrderCheckRecipeView>();

            //this.onUpdateState();
        }
        public UnitOfWork Unit { get { return unit; } }
        public void onSelectedOrderId(int orderId)
        {
            UpdateItemsAndIngredients(orderId);
        }
        public void UpdateItemsAndIngredients(int orderCheckId)
        {
            if (orderCheckId == this.selectedOrderId)
                return;

            items.Clear();
            items.AppendList(GetViewItemsOfOrder(orderCheckId, unit));
            orderRecipeViews.Clear();
            orderRecipeViews.AppendList(GetRecipeOfOrder(orderCheckId, unit));

            this.selectedOrderId = orderCheckId;
        }
        public void LoadDataSet()
        {
        }
        public void onUpdateState()
        {
           
            orders.Clear();
            orders.AppendList(GetOrdersSortedByTime(unit));

            if (selectedOrderId < 0)
                return;

            items.Clear();
            items.AppendList(GetViewItemsOfOrder(selectedOrderId, unit));
            orderRecipeViews.Clear();
            orderRecipeViews.AppendList(GetRecipeOfOrder(selectedOrderId, unit));
        }

        public BindingListEx<ItemView> initItemViewList()
        { 
            return items;
        }
        public BindingListEx<OrderCheck> initOrderCheckList()
        {
            //сразу заполняем для визуала

            orders.Clear();
            orders.AppendList(unit.OrderChecks.GetCollection().ToList());
  
            return orders;
        }
        public BindingListEx<OrderCheckRecipeView> initRecipeViewList()
        {
            return orderRecipeViews;
        }

        public int CreatOrderCheck(String clientNaming)
        {
            OrderCheck newOrder;
            
            newOrder = (new OrderCheck
            {
                ClientName = clientNaming,
                Total = 0,
                OrderTime = DateTime.Now,
            });
            newOrder = unit.OrderChecks.Add(newOrder);

            unit.Save();
            


            return newOrder.Id;
        }
        public void UpdateOrderCheck(int id)
        {
            DataExtractor.UpdateExistOrderCheckParam(id, unit);
        }

        public UnitOfWork GetUnitOfWork()
        {
            return this.unit;
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }

        public void AddUpdateMember(IUpdateMember member)
        {
            throw new NotImplementedException();
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
