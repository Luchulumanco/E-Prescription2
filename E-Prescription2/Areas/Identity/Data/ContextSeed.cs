using E_Prescription2.Models;
using Microsoft.AspNetCore.Identity;


namespace E_Prescription2.Areas.Identity.Data
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Patient.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Doctor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Pharmacist.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "Mukesh",
                LastName = "Murugan",
               

                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Patient.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Doctor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Pharmacist.ToString());
                }

            }
        }
    }
}
