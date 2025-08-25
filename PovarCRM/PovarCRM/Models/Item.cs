using System;
using System.Collections.Generic;

namespace PovarCRM.Models;

public partial class Item 
{
    public int OrderCheckId { get; set; }

    public int DishId { get; set; }

    public int DishCount { get; set; } = 1;

    public virtual Dish Dish { get; set; }

    public virtual OrderCheck OrderCheck { get; set; }
}
