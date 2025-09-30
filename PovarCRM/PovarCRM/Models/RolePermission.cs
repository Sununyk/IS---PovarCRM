using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.Models
{
    public class RolePermission
    {
        public int Id { get; set; }
        public Role Role { get; set; } = null!;

        public String Permission { get; set; } // числовое значение права
    }
}
