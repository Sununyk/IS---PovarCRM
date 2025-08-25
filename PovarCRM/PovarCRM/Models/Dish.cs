using System;
using System.Collections.Generic;
using System.Text;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;
public partial class Dish : IIdentityEntity
{
    public int Id { get; set; }

    public string Naming { get; set; } = null!;

    public decimal Cost { get; set; }

    public int? DishTypeId { get; set; }

    public float Weight { get; set; }
    public virtual DishType? DishType { get; set; }

    public override string ToString()
    {
        return Id.ToString() + " " + Naming;
    }
}
