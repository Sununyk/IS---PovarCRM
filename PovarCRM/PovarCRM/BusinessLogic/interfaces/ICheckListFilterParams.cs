using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.BusinessLogic.interfaces
{

    public interface ICheckListFilterParams
    {
        DateTime EndDatePoint { get; set; }
        DateTime StartDatePoint { get; set; }
        string? ClientName { get; set; }
        int? CheckId { get; set; }
        List<int>? RequiredExistingDishesID { get; set; }
        decimal LowerMoneyConstraint { get; set; }
        decimal HighestMoneyConstraint { get; set; }
        int LowerNumDishesConstraint { get; set; }
        int HighestNumDishesConstraint { get; set; }
        int LowerNumItemConstraint { get; set; }
        int HighestNumItemConstraint { get; set; }
    }
}
