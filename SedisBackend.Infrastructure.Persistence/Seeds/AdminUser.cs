//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SedisBackend.Core.Domain.Entities.Users;
//using SedisBackend.Core.Domain.Entities.Users.Persons;
//using SedisBackend.Core.Domain.Enums;

//namespace SedisBackend.Infrastructure.Persistence.Seeds;

//public static class AdminUser
//{
//    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
//    {
//        List<Admin> adminUsers = new List<Admin>()
//        {
//            new Admin {
//                Id = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
//                UserName = "adminuser",
//                FirstName = "Brahiam",
//                LastName = "Montero",
//                CardId = "40211608647",
//                Email = "adminuser@email.com",
//                PhoneNumber = "829-123-9811",
//                Sex = SexEnum.M,
//                IsActive = true,
//                EmailConfirmed = true,
//                PhoneNumberConfirmed = true,
//                ImageUrl = ".",
//                SecurityStamp = Guid.NewGuid().ToString(),
//                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
//            }
//        };

//        foreach (var adminUser in adminUsers)
//        {
//            var user = await userManager.Users.FirstOrDefaultAsync(u => u.CardId.Equals(adminUser.CardId));
//            if (user == null)
//            {
//                await userManager.CreateAsync(adminUser, "imbrahiam2004$");
//                await userManager.AddToRoleAsync(user, RolesEnum.Admin.ToString());
//            }
//        }
//    }
//}

///*

//{
//  "userName": "johndoe",
//  "firstName": "John",
//  "lastName": "Doe",
//  "email": "john.doe@example.com",
//  "password": "Password123!",
//  "confirmPassword": "Password123!",
//  "idCard": "40208855417",
//  "imageUrl": "https://example.com/johndoe.jpg",
//  "isActive": true,
//  "phoneNumber": "+1234567890",
//  "birthdate": "1985-04-23T00:00:00Z",
//  "sex": "M",
//  "bloodType": "O+",
//  "emergencyContactName": "Jane Doe",
//  "emergencyContactPhone": "+0987654321",
//  "primaryCarePhysicianId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
//}

//*/