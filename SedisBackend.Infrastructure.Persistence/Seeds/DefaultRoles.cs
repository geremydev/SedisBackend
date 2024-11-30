using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public static class DefaultRoles
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        if (!await roleManager.RoleExistsAsync(RolesEnum.Admin.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.Admin.ToString()));
        }

        if (!await roleManager.RoleExistsAsync(RolesEnum.Doctor.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.Doctor.ToString()));
        }

        if (!await roleManager.RoleExistsAsync(RolesEnum.Patient.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.Patient.ToString()));
        }

        if (!await roleManager.RoleExistsAsync(RolesEnum.Assistant.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.Assistant.ToString()));
        }

        if (!await roleManager.RoleExistsAsync(RolesEnum.LabTech.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.LabTech.ToString()));
        }

        if (!await roleManager.RoleExistsAsync(RolesEnum.Registrator.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.Registrator.ToString()));
        }

        if (!await roleManager.RoleExistsAsync(RolesEnum.SuperAdmin.ToString()))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(RolesEnum.SuperAdmin.ToString()));
        }
    }
}
