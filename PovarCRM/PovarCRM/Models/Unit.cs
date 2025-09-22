using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Identity.Client;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;

[ObservableObject]
public partial class Unit : ISingleIdentityEntity, ICopyable<Unit>, ICloneable
{
    [ObservableProperty]
    int id;
    [ObservableProperty]
    string naming = null!;
    [ObservableProperty]
    double weight = 1.0;//in gramm
    public virtual ICollection<DishProduct> DishProducts { get; set; } = new List<DishProduct>();

    // Конструктор копирования
    public Unit() { }
    public Unit(Unit other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));

        Id = other.Id;
        Naming = other.Naming;
        // Поверхностная копия коллекции
       // DishProducts = new List<DishProduct>(other.DishProducts);
    }
    public object Clone()
    {
        return new Unit(this);
    }
    public void Copy(Unit other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));

        id = other.id;
        naming = other.naming;
        // Поверхностная копия коллекции
        //DishProducts = new List<DishProduct>(other.DishProducts);
    }

    public override string ToString()
    {
        return naming;
    }

}