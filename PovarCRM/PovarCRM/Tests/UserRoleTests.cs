using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PovarCRM.Models;

namespace PovarCRM.Tests
{
    internal class UserRoleTests
    {
        //    private PovarDbContext GetInMemoryDb()
        //    {
        //        var options = new DbContextOptionsBuilder<PovarDbContext>()
        //            .UseInMemoryDatabase(databaseName: "TestDb")
        //            .Options;

        //        var context = new PovarDbContext(options, PovarDbContext.DbMode.DataBaseOff);

        //        // Seed данные
        //        var role = new Role { Id = 1, RoleName = "Master" };
        //        var user = new User { Id = 1, UserName = "Sany", RoleId = role.Id, Role = role };
        //        var permissions = new[]
        //        {
        //        new RolePermission { Id = 1, RoleId = role.Id, Permission = "DishProductConstructor" },
        //        new RolePermission { Id = 2, RoleId = role.Id, Permission = "ServingOrders" },
        //        new RolePermission { Id = 3, RoleId = role.Id, Permission = "MenuConstructor" }
        //    };

        //        context.Roles.Add(role);
        //        context.Users.Add(user);
        //        context.RolePermissions.AddRange(permissions);
        //        context.SaveChanges();

        //        return context;
        //    }

        //    [Fact]
        //    public void User_Should_Have_Master_Role_And_Permissions()
        //    {
        //        using var context = GetInMemoryDb();

        //        var user = context.Users
        //            .Include(u => u.Role)
        //            .ThenInclude(r => r.RolePermissions)
        //            .FirstOrDefault(u => u.UserName == "Sany");

        //        Assert.NotNull(user);
        //        Assert.Equal("Master", user.Role.RoleName);

        //        var permissions = user.Role.RolePermissions.Select(p => p.Permission).ToList();
        //        Assert.Contains("DishProductConstructor", permissions);
        //        Assert.Contains("ServingOrders", permissions);
        //        Assert.Contains("MenuConstructor", permissions);
        //    }
    }
}
