using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PovarCRM.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
namespace PovarCRM.Models;

[ObservableObject]
public partial class Dish : ISingleIdentityEntity, ICopyable<Dish>, ICloneable
{
    [ObservableProperty]
     int id;
    [ObservableProperty]
     string naming  = null!;
    [ObservableProperty]
     decimal cost;
    [ObservableProperty]
     int? dishTypeId;
    [ObservableProperty]
     float weight;
    [ObservableProperty]
    float markup = 0.25f;//наценка

    public Dish() { }
    public virtual DishType? DishType { get; set; }

    public override string ToString()
    {
        return Id.ToString() + " " + naming;
    }

    // Конструктор копирования
    public void Copy(Dish other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        Id = other.Id;
        naming = other.naming;
        cost = other.cost;
        dishTypeId = other.dishTypeId;
        weight = other.weight;
// если нужен глубокий клон, можно скопировать DishType отдельно
    }
    public Dish(Dish other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        Id = other.Id;
        naming = other.naming;
        cost = other.cost;
        dishTypeId = other.dishTypeId;
        weight = other.weight;
        // если нужен глубокий клон, можно скопировать DishType отдельно
    }

    public object Clone()
    {
        return new Dish(this);
    }

}
