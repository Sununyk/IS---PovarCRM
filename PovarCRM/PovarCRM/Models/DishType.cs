using System;
using System.Collections.Generic;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;

public partial class DishType : IIdentityEntity
{
    public int Id { get; set; }

    public string Naming { get; set; } = null!;

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
