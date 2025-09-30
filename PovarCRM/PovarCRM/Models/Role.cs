using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PovarCRM.Models
{
    using System.Collections.Generic;
    using Microsoft.VisualBasic.ApplicationServices;

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

        // Связь с пользователями
        public ICollection<User> Users { get; set; } = new List<User>();

        // Права роли (числовые)
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
