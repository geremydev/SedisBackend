using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public static class DefaultUsers
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        var roleAssignments = new Dictionary<Guid, List<string>>
        {
            { Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                Enum.GetNames(typeof(RolesEnum)).ToList() },

            { Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"), new List<string> { RolesEnum.Admin.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"), new List<string> { RolesEnum.Assistant.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"), new List<string> { RolesEnum.Doctor.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"), new List<string> { RolesEnum.Doctor.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"), new List<string> { RolesEnum.LabTech.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"), new List<string> { RolesEnum.LabTech.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"), new List<string> { RolesEnum.LabTech.ToString(), RolesEnum.Patient.ToString() } },
            { Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"), new List<string> { RolesEnum.Patient.ToString() } },
            { Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"), new List<string> { RolesEnum.Patient.ToString() } },
            { Guid.Parse("83d48d7c-6a56-4233-9934-9d30bde63bb5"), new List<string> { RolesEnum.Patient.ToString() } },
            { Guid.Parse("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"), new List<string> { RolesEnum.Patient.ToString() } },
            { Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"), new List<string> { RolesEnum.Patient.ToString() } },
            { Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"), new List<string> { RolesEnum.Patient.ToString() } },
        };

        foreach (var assignment in roleAssignments)
        {
            var user = await userManager.FindByIdAsync(assignment.Key.ToString());
            if (user != null)
            {
                foreach (var role in assignment.Value)
                {
                    if (!await userManager.IsInRoleAsync(user, role))
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}
