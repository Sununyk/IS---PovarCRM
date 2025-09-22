using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PovarCRM.Models.Interfaces
{
    public interface IIdentityEntity
    {
        int[] Id { get; }

        //public bool Validate() {
        //{
        //        for (int i = 0; i < Id.Length; i++)
        //        {
        //            if(Id[i] <= 0)
        //                return false;
        //        }
        //        return true;
        //}
    }
}
