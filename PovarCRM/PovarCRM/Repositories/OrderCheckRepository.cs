using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Models;
using PovarCRM.Repositories.Abstracts;

namespace PovarCRM.Repositories
{
    public class OrderCheckRepository : DefaultRepository<OrderCheck>
    {
        public OrderCheckRepository(PovarDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
