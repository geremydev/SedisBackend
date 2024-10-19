using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public class AssistantUser
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        User assistantUser = new();
        assistantUser.UserName = "assistantuser";
        assistantUser.Email = "assistantuser@email.com";
        assistantUser.PhoneNumber = "829-123-9811";
        assistantUser.IsActive = true;
        assistantUser.EmailConfirmed = true;
        assistantUser.PhoneNumberConfirmed = true;
        assistantUser.ImageUrl = ".";
        assistantUser.SecurityStamp = Guid.NewGuid().ToString();

        var user = await userManager.FindByEmailAsync(assistantUser.Email);
        if (user == null)
        {
            await userManager.CreateAsync(assistantUser, "Pa$$w0rd");
            await userManager.AddToRoleAsync(assistantUser, RolesEnum.Assistant.ToString());
        }
    }
}
