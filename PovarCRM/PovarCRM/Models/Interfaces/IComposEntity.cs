using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PovarCRM.Models.Interfaces
{
    internal interface IComposEntity
    {
        Vector<int> ids { get; }
        int keyCount { get; }
    }
}
