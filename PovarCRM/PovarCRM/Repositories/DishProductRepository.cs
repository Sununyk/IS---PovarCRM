using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Repositories.Abstracts;


namespace PovarCRM.Repositories
{
    public class DishProductRepository : DefaultRepository<DishProduct>
    {
        public DishProductRepository(PovarDbContext dbContext) : base(dbContext)
        {
        }

    }
}
