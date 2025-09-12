using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models.Views
{
    [ObservableObject]
    public partial class DishView : ISingleIdentityEntity, ICloneable, ICopyable<DishView>
    {
        [ObservableProperty]
        private int id;
        [ObservableProperty]
        private string naming = null!;
        [ObservableProperty]
        private decimal cost;
        [ObservableProperty]
        private float weight;
        [ObservableProperty]
        private bool picked = false;
        [ObservableProperty]
        private int count;
        [ObservableProperty]
        private int? dishTypeId;
        public DishView() { }

        public DishView(DishView duplicate)
        {
            Id = duplicate.Id;
            Naming = duplicate.Naming;
            Cost = duplicate.Cost;
            Weight = duplicate.Weight;
            Picked = duplicate.Picked;
            Count = duplicate.Count; 
        }

        public object Clone()
        {
            return new DishView(this);
        }
        public void Copy(DishView source)
        {
            Id = source.Id;
            Naming = source.Naming;
            Cost = source.Cost;
            Weight = source.Weight;
            Picked = source.Picked;
            Count = source.Count;
        }

        //public bool Picked
        //{
        //    get => picked;
        //    set
        //    {
        //        if (picked != value)
        //        {
        //            picked = value;
        //            OnPropertyChanged(nameof(Picked));
        //        }
        //    }
        //}

        //public int Count
        //{
        //    get => picked ? _count : 0;
        //    set
        //    {
        //        if (_count != value)
        //        {
        //            if (picked)
        //            {
        //                _count = value;
        //                if (_count == 0) Picked = false;
        //                OnPropertyChanged(nameof(Count));
        //            }
        //        }
        //    }
        //}

        public override string ToString() => $"{Id} {Naming}";


    }
}
