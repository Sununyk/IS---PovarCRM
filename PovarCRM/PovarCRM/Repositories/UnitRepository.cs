using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PovarCRM.Models;
using PovarCRM.Repositories.Abstracts;

namespace PovarCRM.Repositories
{
    public class UnitRepository : DefaultRepository<Unit>
    {
        public UnitRepository(PovarDbContext context) : base(context)
        {
        }
    }
}
