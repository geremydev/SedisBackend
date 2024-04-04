using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RolesEnum.Patient.ToString()));
        }
    }
}
