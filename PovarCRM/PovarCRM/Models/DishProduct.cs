using System;
using System.Collections.Generic;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;

public partial class DishProduct : IIdentityEntity
{
    public int Id { get; set; }

    public string Naming { get; set; } = null!;

    public decimal Cost { get; set; }

    public int? UnitId { get; set; }

    public virtual Unit? Unit { get; set; }
}
