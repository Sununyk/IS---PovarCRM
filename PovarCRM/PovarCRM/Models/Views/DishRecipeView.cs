using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models.Views
{
    [ObservableObject]
    public partial class DishRecipeView : ICloneable, ICopyable<DishRecipeView>
    {
        [ObservableProperty]
         int dishId;
        [ObservableProperty]
        int dishProductId;
        [ObservableProperty]
        string dishProductNaming;
        [ObservableProperty]
        float countOfUnits;
        [ObservableProperty]
         string unitNaming = null!;
        [ObservableProperty]
        float weight;

        public DishRecipeView() { }
        public DishRecipeView(DishRecipeView dishRecipeView)
        {
            this.dishProductNaming = dishRecipeView.dishProductNaming;
            this.countOfUnits = dishRecipeView.countOfUnits;
            this.unitNaming = dishRecipeView.unitNaming;
        }
        public object Clone()
        {
            return new DishRecipeView(this);
        }

        public void Copy(DishRecipeView other)
        {
            this.dishProductNaming = other.dishProductNaming;
            this.countOfUnits = other.countOfUnits;
            this.unitNaming = other.unitNaming;
        }
    }
    public class OrderCheckRecipeView: ICloneable, ICopyable<OrderCheckRecipeView>
    {
        public OrderCheckRecipeView(string naming, float countOfUnits, string unitNaming)
        {
            Naming = naming;
            this.CountOfUnits = countOfUnits;
            UnitNaming = unitNaming;
        }
        
        public string Naming { get; set; } = null!;
        public float CountOfUnits { get; set; }
        public string UnitNaming { get; set; } = null!;

        public OrderCheckRecipeView(OrderCheckRecipeView recipe)
        {
            this.Naming = recipe.Naming;
            this.CountOfUnits = recipe.CountOfUnits;
            this.UnitNaming = recipe.UnitNaming;
        }
        public object Clone()
        {
            return new OrderCheckRecipeView(this);
        }

        public void Copy(OrderCheckRecipeView other)
        {
            this.Naming = other.Naming;
            this.CountOfUnits = other.CountOfUnits;
            this.UnitNaming = other.UnitNaming;
        }
    }
}
