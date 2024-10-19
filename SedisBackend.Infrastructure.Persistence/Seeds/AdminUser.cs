using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Seeds;

public class AdminUser
{
    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        // Ensure the Admin role exists
        var adminRoleName = RolesEnum.Admin.ToString();
        if (!await roleManager.RoleExistsAsync(adminRoleName))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>(adminRoleName));
        }

        // Create the admin user
        var adminUser = new User
        {
            UserName = "adminuser",
            FirstName = "Brahiam",
            LastName = "Montero",
            CardId = "40211608647",
            Email = "adminuser@email.com",
            PhoneNumber = "829-123-9811",
            IsActive = true,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            ImageUrl = ".",
            SecurityStamp = Guid.NewGuid().ToString()
        };

        // Check if the user already exists
        var user = await userManager.FindByEmailAsync(adminUser.Email);
        if (user == null)
        {
            var result = await userManager.CreateAsync(adminUser, "Pa$$w0rd12341234");
            if (result.Succeeded)
            {
                // Add the user to the Admin role
                await userManager.AddToRoleAsync(adminUser, adminRoleName);
            }
            else
            {
                // Handle errors during user creation
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create admin user: {errors}");
            }
        }
        else
        {
            // Ensure the existing user is in the Admin role
            if (!await userManager.IsInRoleAsync(user, adminRoleName))
            {
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
        }
    }
}

/*

{
  "userName": "johndoe",
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com",
  "password": "Password123!",
  "confirmPassword": "Password123!",
  "idCard": "40208855417",
  "imageUrl": "https://example.com/johndoe.jpg",
  "isActive": true,
  "phoneNumber": "+1234567890",
  "birthdate": "1985-04-23T00:00:00Z",
  "sex": "M",
  "bloodType": "O+",
  "emergencyContactName": "Jane Doe",
  "emergencyContactPhone": "+0987654321",
  "primaryCarePhysicianId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}

*/