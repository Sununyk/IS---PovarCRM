using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models;
[ObservableObject]
public partial class Recipe : IIdentityEntity, ICopyable<Recipe>
{
    [ObservableProperty]
    int dishId;
    [ObservableProperty]
    int dishProductId;
    [ObservableProperty]
    float countOfUnits;
    public virtual Dish Dish { get; set; }
    public virtual DishProduct DishProduct { get; set; }
    public int[] Id => new int[2] { dishId, dishProductId };

    // Конструктор копирования
    public Recipe() { }
    //public Recipe(Recipe other)
    //{
    //    if (other == null) throw new ArgumentNullException(nameof(other));
    //    DishId = other.DishId;
    //    DishProductId = other.DishProductId;
    //    CountOfUnits = other.CountOfUnits;
    //    Dish = other.Dish; // поверхностное копирование
    //    DishProduct = other.DishProduct; // поверхностное копирование
    //}

    public void Copy(Recipe other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        dishId = other.dishId;
        dishProductId = other.dishProductId;
        countOfUnits = other.countOfUnits;

        //Dish = other.Dish; // поверхностное копирование
        //DishProduct = other.DishProduct; // поверхностное копирование
    }

    // Метод клонирования

}