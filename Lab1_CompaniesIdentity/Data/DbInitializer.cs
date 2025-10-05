using Lab1_CompaniesIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Lab1_CompaniesIdentity.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsersAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Ensures roles exist
            string[] roles = { "Admin", "Supervisor", "Employee" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Creates a Supervisor user
            var supervisorEmail = "supervisor@mohawk.ca";
            if (await userManager.FindByEmailAsync(supervisorEmail) == null)
            {
                var supervisor = new ApplicationUser
                {
                    UserName = supervisorEmail,
                    Email = supervisorEmail,
                    FirstName = "Super",
                    LastName = "Visor",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(supervisor, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(supervisor, "Supervisor");
                }
            }

            // Creates an Employee user
            var employeeEmail = "employee@mohawk.ca";
            if (await userManager.FindByEmailAsync(employeeEmail) == null)
            {
                var employee = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    FirstName = "Emp",
                    LastName = "Loyee",
                    EmailConfirmed = true
                };

                    var result = await userManager.CreateAsync(employee, "Password123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(employee, "Employee");
                }
            }

            // Creates an Admin user
            var adminEmail = "admin@mohawk.ca";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "System",
                    LastName = "Admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "AdminPassword123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
