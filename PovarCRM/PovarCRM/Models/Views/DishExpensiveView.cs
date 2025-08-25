using System;
using System.Collections.Generic;

namespace PovarCRM.Models.Views;

public partial class DishExpensiveView
{
    public int Id { get; set; }

    public string Naming { get; set; } = null!;

    public double? SummaryCost { get; set; }
}
