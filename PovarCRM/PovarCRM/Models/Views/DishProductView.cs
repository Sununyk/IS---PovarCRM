using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models.Views
{
        [ObservableObject]
        public partial class DishProductView : ISingleIdentityEntity, ICopyable<DishProductView>, ICloneable
        {
            int id;
            [ObservableProperty]
            string naming = null!;
            [ObservableProperty]
            decimal cost;
            [ObservableProperty]
            int? unitId;
            [ObservableProperty]
            string unitName;
            [ObservableProperty]
            double weight;
            public virtual Unit? Unit { get; set; }
            public int Id { get => id; set => id = value; }

            // Конструктор копирования
            public DishProductView() { }
            public DishProductView(DishProductView other)
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
                return new DishProductView(this);
            }
            public void Copy(DishProductView other)
            {
                if (other == null) throw new ArgumentNullException(nameof(other));
                id = other.id;
                naming = other.naming;
                cost = other.cost;
                unitId = other.unitId;
                //Unit = other.Unit; // ссылка, глубокое копирование при необходимости
            }
            public DishProduct ToDishProduct()
            {
                return new DishProduct { Cost = this.cost, UnitId = this.unitId, Id = this.id, Naming = this.naming, Weight = this.weight };
            }

    }
}
