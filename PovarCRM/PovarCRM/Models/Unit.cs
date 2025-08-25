using System;
using System.Collections.Generic;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;

public partial class Unit : IIdentityEntity
{
    public int Id { get; set; }

    public string Naming { get; set; } = null!;

    public virtual ICollection<DishProduct> DishProducts { get; set; } = new List<DishProduct>();
}
