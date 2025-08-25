using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IDishTypeRepository
    {
        IEnumerable<DishType> GetDishTypes();
        DishType GetDishTypeByID(int dishTypeID);
        void InsertDishType(DishType dishType);
        void DeleteDishType(int dishTypeID);
        void UpdateDishType(DishType dishType);
        void Save();
    }
}
