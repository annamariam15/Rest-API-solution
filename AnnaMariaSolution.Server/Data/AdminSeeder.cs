using Microsoft.AspNetCore.Identity;
using AnnaMariaSolution.Server.Models;

namespace AnnaMariaSolution.Server.Data
{
    public static class AdminSeeder
    {
        public static async Task SeedAdmin(
            UserManager<User> userManager)
        {
            var adminEmail = "admin@company.com";
            var adminPassword = "Admin123!";


            var existingAdmin =
                await userManager.FindByEmailAsync(adminEmail);


            if (existingAdmin == null)
            {
                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };


                var result =
                    await userManager.CreateAsync(
                        admin,
                        adminPassword);


                if (!result.Succeeded)
                {
                    throw new Exception(
                        string.Join(
                            ", ",
                            result.Errors.Select(e => e.Description)
                        ));
                }


                existingAdmin = admin;
            }


            if (!await userManager.IsInRoleAsync(
                existingAdmin,
                "Admin"))
            {
                await userManager.AddToRoleAsync(
                    existingAdmin,
                    "Admin");
            }
        }
    }
}
