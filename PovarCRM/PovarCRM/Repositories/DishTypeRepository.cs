using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Models;
using PovarCRM.Repositories.Abstracts;

namespace PovarCRM.Repositories
{
    public class DishTypeRepository : DefaultRepository<DishType>
    {
        public DishTypeRepository(DbContext context) : base(context) { }
    }
}
