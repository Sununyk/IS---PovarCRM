using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models.Views
{
    public class DishRecipeView : ICloneable, ICopyable<DishRecipeView>
    {
        public string DishProductNaming { get; set; }
        public float CountOfUnits { get; set; }
        public string UnitNaming { get; set; } = null!;

        public DishRecipeView() { }
        public DishRecipeView(DishRecipeView dishRecipeView)
        {
            this.DishProductNaming = dishRecipeView.DishProductNaming;
            this.CountOfUnits = dishRecipeView.CountOfUnits;
            this.UnitNaming = dishRecipeView.UnitNaming;
        }
        public object Clone()
        {
            return new DishRecipeView(this);
        }

        public void Copy(DishRecipeView other)
        {
            this.DishProductNaming = other.DishProductNaming;
            this.CountOfUnits = other.CountOfUnits;
            this.UnitNaming = other.UnitNaming;
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
