using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;

namespace PovarCRM.Repositories.Interfaces.garbij
{
    internal interface IDishProductRepository
    {
        IEnumerable<DishProduct> GetDishProduct();
        DishProduct GetDishProductByID(int dishProductID);
        void InsertDishProduct(DishProduct dishProduct);
        void DeleteDishProduct(int dishProductID);
        void UpdateDishProduct(DishProduct dishProduct);
        void Save();
    }
}
