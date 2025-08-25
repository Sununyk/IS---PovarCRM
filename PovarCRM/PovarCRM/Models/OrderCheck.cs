using System;
using System.Collections.Generic;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;
public partial class OrderCheck : IIdentityEntity
{
    public int Id { get; set; }

    string? IIdentityEntity.Naming { get => ClientName; set => ClientName = value; }
    public string? ClientName { get; set; } = string.Empty;
    public decimal Total { get; set; }

    public DateTime OrderTime { get; set; }

}
