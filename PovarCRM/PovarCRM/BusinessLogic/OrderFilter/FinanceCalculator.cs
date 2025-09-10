using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.IdentityModel.Tokens;
using PovarCRM.Models;



namespace PovarCRM.BusinessLogic.OrderFilter
{
    public interface ICheckListCalculator
    {
        public List<OrderCheck> GetFilteredCheckList(
            CheckListFilterParams parameters
            
        );
    }

    public class FinanceCalculator : ICheckListCalculator
    {
        private UnitOfWork unitOfWork;
        public FinanceCalculator(UnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        IEnumerable<OrderCheck> Checks { get; set; }

        public List<OrderCheck> GetFilteredCheckList(CheckListFilterParams param)
        {
            List<OrderCheck>? checkList = unitOfWork.OrderChecks.GetCollection().ToList();
            List<OrderCheck> filtCheckList = new List<OrderCheck>();
            List<Item> CheckItems = unitOfWork.Items.GetCollection().ToList();

            List<int> listOrderCheckId = (from i in checkList
                    where i.OrderTime >= param.StartDatePoint && i.OrderTime <= param.EndDatePoint
                    where i.Total >= param.LowerMoneyConstraint && i.Total <= param.HighestMoneyConstraint
                    join j in CheckItems on i.Id equals j.OrderCheckId
                    group j by i.Id into g
                    where g.Sum(x => x.DishCount) >= param.LowerNumDishesConstraint
                        && g.Sum(x => x.DishCount) <= param.HighestNumDishesConstraint
                    where g.Count() >= param.LowerNumItemConstraint
                        && g.Count() <= param.HighestNumItemConstraint
                    select g.Key
            ).ToList();

            filtCheckList = (from i in listOrderCheckId
                             join o in checkList on i equals o.Id
                             select o).ToList();

            if (!param.RequiredExistingDishesID.IsNullOrEmpty())
            {
                filtCheckList = (from i in filtCheckList
                                 join j in CheckItems on i.Id equals j.OrderCheckId
                                 group j by i into g
                                 where param.RequiredExistingDishesID.All(DishId => g.Any(item => item.DishId == DishId))
                                 select g.Key).ToList();
            }

            if (param.CheckId != null && param.CheckId > 0)
            {
                filtCheckList = (from o in filtCheckList
                                 where o.Id == param.CheckId
                                 select o).ToList();
            }
            else if(!param.ClientName.IsNullOrEmpty())
            {
                filtCheckList = (from o in filtCheckList
                                 where o.ClientName == param.ClientName
                                 select o).ToList();
            }
            return filtCheckList;

        }
    }

}
