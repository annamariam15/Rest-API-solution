using Microsoft.AspNetCore.Identity;
using AnnaMariaSolution.Server.Models;

//FOR TESTING PURPOSES ONLY
namespace AnnaMariaSolution.Server.Data
{
    public static class EmployeeSeeder
    {
        public static async Task SeedEmployee(
            UserManager<User> userManager)
        {
            var employeeEmail = "john";
            var employeePassword = "John123!";


            var existingEmployee =
                await userManager.FindByEmailAsync(employeeEmail);


            if (existingEmployee == null)
            {
                var employee = new User
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true
                };


                var result =
                    await userManager.CreateAsync(
                        employee,
                        employeePassword);


                if (!result.Succeeded)
                {
                    throw new Exception(
                        string.Join(
                            ", ",
                            result.Errors.Select(e => e.Description)
                        ));
                }


                existingEmployee = employee;
            }


            if (!await userManager.IsInRoleAsync(
                existingEmployee,
                "Employee"))
            {
                await userManager.AddToRoleAsync(
                    existingEmployee,
                    "Employee");
            }
        }
    }
}
