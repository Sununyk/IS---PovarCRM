using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;
using PovarCRM.Models.Views;

namespace PovarCRM.Models;

[ObservableObject]
public partial class DishProduct : ISingleIdentityEntity, ICopyable<DishProduct>, ICloneable
{
    [ObservableProperty]
     int id;
    [ObservableProperty]
     string naming= null!;
    [ObservableProperty]
     decimal cost;
    [ObservableProperty]
    double weight = 1.0f;
    [ObservableProperty]
     int? unitId;
    public virtual Unit? Unit { get; set; }

    // Конструктор копирования
    public DishProduct() { }
    public DishProduct(DishProduct other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        Id = other.Id;
        Naming = other.Naming;
        Cost = other.Cost;
        UnitId = other.UnitId;
        //Unit = other.Unit; // ссылка, глубокое копирование при необходимости
    }
    public object Clone()
    {
        return new DishProduct(this);
    }
    public void Copy(DishProduct other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        id = other.id;
        naming = other.naming;
        cost = other.cost;
        unitId = other.unitId;
        weight = other.weight;
        //Unit = other.Unit; // ссылка, глубокое копирование при необходимости
    }

}
