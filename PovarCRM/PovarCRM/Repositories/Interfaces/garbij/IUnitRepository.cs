using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IUnitRepository
    {
        IEnumerable<Unit> GetUnits();
        Unit GetUnitByID(int UnitID);
        void InsertUnit(Unit Unit);
        void DeleteUnit(int UnitID);
        void UpdateUnit(Unit Unit);
        void Save();
    }
}
