using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public class SuperAdmin
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        User adminuser = new();
        adminuser.UserName = "superadminuser";
        adminuser.Email = "superadminuser@email.com";
        adminuser.PhoneNumber = "";
        adminuser.Status = true;
        adminuser.EmailConfirmed = true;
        adminuser.PhoneNumberConfirmed = true;
        adminuser.ImageUrl = ".";
        adminuser.SecurityStamp = Guid.NewGuid().ToString();

        var user = await userManager.FindByEmailAsync(adminuser.Email);

        if (user == null)
        {
            await userManager.CreateAsync(adminuser, "Pa$$w0rd");
            await userManager.AddToRoleAsync(adminuser, RolesEnum.Admin.ToString());
        }
    }
}
