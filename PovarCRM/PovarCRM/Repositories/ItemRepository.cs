using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Repositories.Abstracts;

namespace PovarCRM.Repositories
{
    public class ItemRepository : DefaultRepository<Item>
    {
        public ItemRepository(PovarDbContext dbContext) : base(dbContext) { }
    }
}
