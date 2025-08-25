using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Repositories.Abstracts;

namespace PovarCRM.Repositories
{
    public class DishRepository : DefaultRepository<Models.Dish>
    {
        public DishRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
