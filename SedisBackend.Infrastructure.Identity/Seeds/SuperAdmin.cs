using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Infrastructure.Identity.Entities;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class SuperAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser adminuser = new();
            adminuser.UserName = "superadminuser";
            adminuser.Email = "superadminuser@email.com";
            adminuser.PhoneNumber = "829-123-9811";
            adminuser.IsActive = true;
            adminuser.EmailConfirmed = true;
            adminuser.PhoneNumberConfirmed = true;
            adminuser.ImageUrl = ".";

            var user = await userManager.FindByEmailAsync(adminuser.Email);

            if (user == null)
            {
                await userManager.CreateAsync(adminuser, "Pa$$w0rd");
                await userManager.AddToRoleAsync(adminuser, RolesEnum.Admin.ToString());
            }
        }
    }
}
