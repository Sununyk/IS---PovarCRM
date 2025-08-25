using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.Models.Views
{
    public class ItemView
    {
        public int DishId { get; set; }

        public string DishNaming { get; set; }
        public int DishCount { get; set; } = 1;
        public SqlMoney ItemCost { get; set; }

    }
}
