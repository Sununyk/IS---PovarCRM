using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;

[ObservableObject]
public partial class DishType : ISingleIdentityEntity, ICopyable<DishType>, ICloneable
{
    [ObservableProperty]
     int id;
    [ObservableProperty]
     string naming = null!;

    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public object Clone()
    {
        DishType dishType = new DishType();
        dishType.Copy(this);
        return dishType;
    }

    // Конструктор копирования
    public void Copy(DishType other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        id = other.id;
        naming = other.naming;


        //Dishes = new List<Dish>();
        //foreach (var dish in other.Dishes)
        //{
        //    Dishes.Add(new Dish());
        //    Dishes.Last().Copy(dish);// потребуется конструктор копирования у Dish
        //}


    }
}
