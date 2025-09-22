using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.Models.Interfaces
{
    public interface ISingleIdentityEntity
    {
        int Id { get; set; }
        //string Naming { get; set; }

        //public bool Validate()
        //{
        //    if(Id <= 0)
        //        return false;
        //    return true;
        //}
        //public string ToString()
        //{
        //    return $"#{Id}: {Naming}";
        //}
    }
}
