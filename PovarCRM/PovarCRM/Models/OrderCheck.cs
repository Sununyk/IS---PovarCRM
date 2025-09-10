using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;
[ObservableObject]
public partial class OrderCheck : ISingleIdentityEntity, ICopyable<OrderCheck>, ICloneable
{
    [ObservableProperty]
     int id;
    [ObservableProperty]
    string? clientName;

    [ObservableProperty]
     decimal total;
    [ObservableProperty]
     DateTime orderTime;

    //public string? Naming { get { return clientName; } set { clientName = value; } }
    public OrderCheck() { }
    // Конструктор копирования
    public OrderCheck(OrderCheck other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        id = other.id;
        ClientName = other.ClientName;
        Total = other.Total;
        OrderTime = other.OrderTime;
    }
    public object Clone()
    {
        return new OrderCheck(this);
    }


    public void Copy(OrderCheck other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        id = other.id;
        total = other.total;
        orderTime = other.orderTime;
    }

}