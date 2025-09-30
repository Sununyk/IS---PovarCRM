using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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

    }
}
