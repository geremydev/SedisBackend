//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SedisBackend.Core.Domain.Entities.Users;
//using SedisBackend.Core.Domain.Entities.Users.Persons;
//using SedisBackend.Core.Domain.Enums;

//namespace SedisBackend.Infrastructure.Persistence.Seeds;

//public static class DoctorUser
//{
//    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
//    {
//        List<Doctor> doctorUsers = new List<Doctor>()
//        {
//            new Doctor {
//                Id = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
//                FirstName = "John",
//                LastName = "Doe",
//                CardId = "1234567890",
//                IsActive = true,
//                Birthdate = new DateTime(1980, 5, 15),
//                Sex = SexEnum.M,
//                UserName = "doctoruser",
//                Email = "doctoruser@email.com",
//                PhoneNumber = "829-123-9812",
//                EmailConfirmed = true,
//                PhoneNumberConfirmed = true,
//                ImageUrl = ".",
//                SecurityStamp = Guid.NewGuid().ToString(),
//                LicenseNumber = "LIC12345678",
//            },
//            new Doctor {
//                Id = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
//                UserName = "doctoruser2",
//                Email = "doctoruser2@email.com",
//                FirstName = "Jane",
//                LastName = "Smith",
//                CardId = "0987654321",
//                IsActive = false,
//                Birthdate = new DateTime(1975, 12, 1),
//                Sex = SexEnum.F,
//                PhoneNumber = "829-123-9231",
//                EmailConfirmed = true,
//                PhoneNumberConfirmed = true,
//                ImageUrl = ".",
//                SecurityStamp = Guid.NewGuid().ToString(),
//                LicenseNumber = "LIC98765432",
//            }
//        };

//        foreach (var doctorUser in doctorUsers)
//        {
//            var user = await userManager.Users.FirstOrDefaultAsync(u => u.CardId.Equals(doctorUser.CardId));
//            if (user == null)
//            {
//                await userManager.CreateAsync(doctorUser, "Pa$$w0rddddd");
//                await userManager.AddToRoleAsync(user, RolesEnum.Doctor.ToString());
//            }
//        }
//    }
//}
