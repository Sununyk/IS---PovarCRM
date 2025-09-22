using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;
[ObservableObject]
public partial class Item : IIdentityEntity, ICopyable<Item>, ICloneable
{
    public Item() { }

    [ObservableProperty]
    int orderCheckId;
    [ObservableProperty]
    int dishId;
    [ObservableProperty]
    int dishCount = 1;

     public virtual Dish Dish { get; set; } = null!;
    
     public virtual OrderCheck OrderCheck { get; set; } = null!;

    public int[] Id => new int[2] { orderCheckId, dishId };


    // Конструктор копирования
    public Item(Item other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        OrderCheckId = other.OrderCheckId;
        DishId = other.DishId;
        DishCount = other.DishCount;
        //Dish = other.Dish; // поверхностная копия ссылки
        //OrderCheck = other.OrderCheck; // поверхностная копия ссылки
    }
    public void Copy(Item other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
       // orderCheckId = other.orderCheckId;
       // dishId = other.dishId;
        this.dishCount = other.dishCount;

       // Dish = other.Dish; // поверхностная копия ссылки
        //OrderCheck = other.OrderCheck; // поверхностная копия ссылки
    }

    public object Clone()
    {
        return new Item(this);
    }
}