using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public class PatientUser
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        User clientUser = new();
        clientUser.UserName = "patient";
        clientUser.Email = "patientuser@email.com";
        clientUser.PhoneNumber = "829-123-9811";
        clientUser.IsActive = true;
        clientUser.EmailConfirmed = true;
        clientUser.PhoneNumberConfirmed = true;
        clientUser.ImageUrl = ".";
        clientUser.SecurityStamp = Guid.NewGuid().ToString();

        var user = await userManager.FindByEmailAsync(clientUser.Email);
        if (user == null)
        {
            await userManager.CreateAsync(clientUser, "Pa$$w0rd");
            await userManager.AddToRoleAsync(clientUser, RolesEnum.Patient.ToString());
        }
    }
}
