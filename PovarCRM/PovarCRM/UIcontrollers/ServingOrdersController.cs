using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using System.Windows.Forms;
using PovarCRM.Models.Views;

namespace PovarCRM.UIcontrollers
{
    public class ServingOrdersController
    {
        private BindingListEx<OrderCheck> orders;
        private BindingListEx<ItemView> items;
        public ServingOrdersController()
        {
            orders = new BindingListEx<OrderCheck>();
            items = new BindingListEx<ItemView>();
        }

        void UpdateState(int orderCheckId)
        {
            using (var unit = new UnitOfWork())
            {
                orders.Clear();
                orders.AppendList(unit.OrderChecks.GetCollection().ToList());

                if (orderCheckId < 0)
                    return;

                items.Clear();
                items.AppendList(GetViewItemsOfOrder(orderCheckId));
            }
        }
        public BindingListEx<ItemView> initItemViewList()
        { 
            return items;
        }
        public BindingListEx<OrderCheck> initOrderCheckList()
        {
            using (var unit = new UnitOfWork())
            {
                orders.Clear();
                orders.AppendList(unit.OrderChecks.GetCollection().ToList());
            }
            return orders;
        }
        
        public List<ItemView> GetViewItemsOfOrder(int orderId)
        {
            List<ItemView> itemList = new List<ItemView>();

            using (var unit = new UnitOfWork())
            {
                try
                {
                    OrderCheck pickedOrder = unit.OrderChecks.GetByID(orderId);
                    List<Item> items = new List<Item>();
                    itemList.AddRange(
                         from item in unit.Items.GetCollection()
                         where item.OrderCheckId == orderId
                         join d in unit.Dishes.GetCollection() on item.DishId equals d.Id
                         select new ItemView
                         {
                             DishId = item.DishId,
                             DishNaming = d.Naming,
                             DishCount = item.DishCount,
                             ItemCost = d.Cost * item.DishCount,
                         }
                    );
                }
                catch (Exception ex)
                {
                    UpdateState(-1);
                }
            }
            return itemList;
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
