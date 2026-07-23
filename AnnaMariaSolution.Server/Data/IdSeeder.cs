using AnnaMariaSolution.Server.Models;
using Microsoft.AspNetCore.Identity;
namespace AnnaMariaSolution.Server.Data
{
    public static class IdentitySeeder
    {
        public static async Task SeedRoles(
            RoleManager<Role> roleManager)
        {
            string[] roles =
            {
            "Admin",
            "Employee"
        };


            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(
                        new Role
                        {
                            Name = role
                        });
                }
            }
        }
    }
}
