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
using QuestPDF.Fluent;
using System.Configuration;
using Microsoft.Web.WebView2.Core;

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
        public void PrintCheck(int orderCheckId)
        {
            OrderCheck order = unit.OrderChecks.GetByID(orderCheckId);

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
        //return pdf path
        public String CreatOrderPDF()
        {
            OrderCheck newOrder = unit.OrderChecks.GetByID(this.selectedOrderId);
            var check = new Documents.OrderPDFComposer(
                newOrder,
                this.items.ToList()
            );
            String datatime = newOrder.OrderTime.ToString("yy-mm-dd");
            String pdfPath = $"{ConfigurationManager.AppSettings["OrderCheckFolderPath"]}\\Order_{newOrder.Id}_{datatime}.pdf";
            check.GeneratePdf(pdfPath);

            return pdfPath;
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


    }
}
