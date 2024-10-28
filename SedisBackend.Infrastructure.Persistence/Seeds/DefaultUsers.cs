using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public static class DefaultUsers
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        var roleAssignments = new Dictionary<Guid, string>
        {
            { Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), RolesEnum.Admin.ToString() },
            { Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), RolesEnum.Assistant.ToString() },
            { Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), RolesEnum.Patient.ToString() },
            { Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), RolesEnum.Patient.ToString() },
            { Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), RolesEnum.Doctor.ToString() },
            { Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), RolesEnum.Doctor.ToString() },
            { Guid.Parse("df29ab27-9e74-4abe-9cc9-9ed47300f7c1"), RolesEnum.Enroller.ToString() }
        };

        foreach (var assignment in roleAssignments)
        {
            var user = await userManager.FindByIdAsync(assignment.Key.ToString());
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, assignment.Value);
            }
        }
    }
}
