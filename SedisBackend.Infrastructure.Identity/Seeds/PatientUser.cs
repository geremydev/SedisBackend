using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Infrastructure.Identity.Entities;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class PatientUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser clientUser = new();
            clientUser.UserName = "patient";
            clientUser.Email = "patientuser@email.com";
            clientUser.PhoneNumber = "829-123-9811";
            clientUser.IsActive = true;
            clientUser.EmailConfirmed = true;
            clientUser.PhoneNumberConfirmed = true;
            clientUser.ImageUrl = ".";

            var user = await userManager.FindByEmailAsync(clientUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(clientUser, "Pa$$w0rd");
                await userManager.AddToRoleAsync(clientUser, RolesEnum.Patient.ToString());
            }
        }
    }
}
