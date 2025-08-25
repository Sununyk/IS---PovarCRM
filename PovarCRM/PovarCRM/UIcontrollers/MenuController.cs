using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Models.Views;

namespace PovarCRM.UIcontrollers
{
    enum MenuMode
    {
        Picker,
        Modify
    }
    internal class MenuController
    {
        BindingListEx<DishType> dishTypes;
        BindingListEx<DishView> dishes;
        private MenuMode Mode { get; set; }

        public BindingListEx<DishType> initDishTypeList()
        {
            return dishTypes;
        }
        public BindingListEx<DishView> initDishViewList()
        {
            return dishes;
        }

    }
}
