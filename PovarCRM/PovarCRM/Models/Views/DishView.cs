using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models.Interfaces;

namespace PovarCRM.Models.Views
{
    public partial class DishView : IIdentityEntity
    {
        public int Id { get; set; }

        public string Naming { get; set; } = null!;

        public decimal Cost { get; set; }

        public float Weight { get; set; }

        public bool Picked { get; set; } = false;

        public int Count
        {
            get
            {
                if (!Picked)
                    return 0;
                return Count;
            }
            set
            {
                if (Picked)
                {
                    Count = value;
                }
            }
        }

        public override string ToString()
        {
            return Id.ToString() + " " + Naming;
        }
    }

}
