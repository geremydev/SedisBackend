using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Infrastructure.Identity.Entities;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(RolesEnum.SuperAdmin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(RolesEnum.SuperAdmin.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(RolesEnum.Admin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(RolesEnum.Admin.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(RolesEnum.Patient.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(RolesEnum.Patient.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(RolesEnum.Assistant.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(RolesEnum.Assistant.ToString()));
            }
        }
    }
}
