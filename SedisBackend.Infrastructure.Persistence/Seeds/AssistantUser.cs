//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SedisBackend.Core.Domain.Entities.Users;
//using SedisBackend.Core.Domain.Entities.Users.Persons;
//using SedisBackend.Core.Domain.Enums;

//namespace SedisBackend.Infrastructure.Persistence.Seeds;

//public static class AssistantUser
//{
//    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
//    {
//        List<Assistant> assistantUsers = new List<Assistant>()
//        {
//            new Assistant {
//                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
//                UserName = "assistantuser",
//                Email = "assistantuser@email.com",
//                FirstName = "Ana",
//                LastName = "Martínez",
//                CardId = "0987634321",
//                Birthdate = new DateTime(1995, 12, 1),
//                Sex = SexEnum.F,
//                PhoneNumber = "829-123-9811",
//                IsActive = false,
//                EmailConfirmed = true,
//                PhoneNumberConfirmed = true,
//                ImageUrl = ".",
//                SecurityStamp = Guid.NewGuid().ToString(),
//                HealthCenterId = Guid.Parse("85bc224a-c53f-41db-97b8-92f703ee4452"),
//            },
//        };

//        foreach (var assistantUser in assistantUsers)
//        {
//            var user = await userManager.Users.FirstOrDefaultAsync(u => u.CardId.Equals(assistantUser.CardId));
//            if (user == null)
//            {
//                await userManager.CreateAsync(assistantUser, "Pa$$w0rddddd");
//                await userManager.AddToRoleAsync(user, RolesEnum.Assistant.ToString());
//            }
//        }
//    }
//}
