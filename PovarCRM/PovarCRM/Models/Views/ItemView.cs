using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models.Views
{
    [ObservableObject]
    public partial class ItemView : ICloneable, ICopyable<ItemView>
    {
        [ObservableProperty]
        int dishId;
        [ObservableProperty]
        string dishNaming;
        [ObservableProperty]
        float dishWeight;
        [ObservableProperty]
        int dishCount = 1;
        [ObservableProperty]
        SqlMoney itemCost;
        public ItemView() { }
            
        public ItemView(ItemView item)
        {
            this.DishCount = item.DishCount;
            this.DishId = item.DishId;
            this.DishWeight = item.DishWeight;
            this.ItemCost = item.ItemCost;
            this.DishNaming = item.DishNaming;
        }
        public object Clone()
        {
            return new ItemView(this);
        }

        public void Copy(ItemView other)
        {
            this.DishCount = other.DishCount;
            this.DishId = other.DishId;
            this.DishWeight = other.DishWeight;
            this.ItemCost = other.ItemCost;
            this.DishNaming = other.DishNaming;
        }
    }
}
