using System;
using System.Collections.Generic;

namespace PovarCRM.Models;
public partial class Recipe
{
    public int DishId { get; set; }

    public int DishProductId { get; set; }

    public float CountOfUnits { get; set; }

    public virtual Dish Dish { get; set; }

    public virtual DishProduct DishProduct { get; set; }
}
