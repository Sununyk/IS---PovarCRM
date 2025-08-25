using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IDishRepository
    {
        IEnumerable<Dish> GetDishes();
        Dish GetcheckItemByID(int checkItemID);
        void InsertCheckItem(Dish checkItem);
        void DeleteCheckItem(int checkItemID);
        void UpdateCheckItem(Dish checkItem);
        void Save();
    }
}
