using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.BusinessLogic.OrderFilter.interfaces;

namespace PovarCRM.BusinessLogic.OrderFilter
{
    public class CheckListFilterParams : ICheckListFilterParams
    {
        public DateTime EndDatePoint { get; set; } = DateTime.Now;
        public DateTime StartDatePoint { get; set; } = new DateTime(1753, 1, 1, 1, 1, 1);
        public string? ClientName { get; set; } = null;
        public int? CheckId { get; set; } = null;
        public List<int>? RequiredExistingDishesID { get; set; } = new List<int>();
        public decimal LowerMoneyConstraint { get; set; } = decimal.MinValue;
        public decimal HighestMoneyConstraint { get; set; } = decimal.MaxValue;
        public int LowerNumDishesConstraint { get; set; } = 0;
        public int HighestNumDishesConstraint { get; set; } = int.MaxValue;
        public int LowerNumItemConstraint { get; set; } = 0;
        public int HighestNumItemConstraint { get; set; } = int.MaxValue;
    }
}
