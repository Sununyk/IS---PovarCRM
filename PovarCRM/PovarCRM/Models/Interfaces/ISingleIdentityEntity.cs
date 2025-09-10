using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.Models.Interfaces
{
    public interface ISingleIdentityEntity
    {
        int Id { get; set; }
        //string Naming { get; set; }

        //public string ToString()
        //{
        //    return $"#{Id}: {Naming}";
        //}
    }
}
