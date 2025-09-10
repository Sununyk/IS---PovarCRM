using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;

[ObservableObject]
public partial class Unit : ISingleIdentityEntity, ICopyable<Unit>
{
    [ObservableProperty]
    int id;
    [ObservableProperty]
    string naming = null!;
    public virtual ICollection<DishProduct> DishProducts { get; set; } = new List<DishProduct>();

    // Конструктор копирования
    public Unit() { }
    //public Unit(Unit other)
    //{
    //    if (other == null) throw new ArgumentNullException(nameof(other));

    //    Id = other.Id;
    //    Naming = other.Naming;
    //    // Поверхностная копия коллекции
    //    DishProducts = new List<DishProduct>(other.DishProducts);
    //}
    public void Copy(Unit other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));

        id = other.id;
        naming = other.naming;
        // Поверхностная копия коллекции
        //DishProducts = new List<DishProduct>(other.DishProducts);
    }

}