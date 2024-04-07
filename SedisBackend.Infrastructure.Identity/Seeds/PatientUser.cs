using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Enums;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Infrastructure.Identity.Entities;

namespace SedisBackend.Infrastructure.Identity.Seeds
{
    public class PatientUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser clientuser = new();
            clientuser.UserName = "patient";
            clientuser.Email = "patientuser@email.com";
            clientuser.PhoneNumber = "829-123-9811";
            clientuser.EmailConfirmed = true;
            clientuser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != clientuser.Id))
            {
                var user = await userManager.FindByEmailAsync(clientuser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(clientuser, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(clientuser, RolesEnum.Patient.ToString());
                }
            }
        }
    }
}
