//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using SedisBackend.Core.Domain.Entities.Users;
//using SedisBackend.Core.Domain.Entities.Users.Persons;
//using SedisBackend.Core.Domain.Enums;

//namespace SedisBackend.Infrastructure.Persistence.Seeds;

//public static class PatientUser
//{
//    public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
//    {
//        List<Patient> patientUsers = new List<Patient>()
//        {
//            new Patient {
//                Id = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
//                UserName = "patient",
//                Email = "patientuser@email.com",
//                CardId = "40211608640",
//                FirstName = "John",
//                LastName = "Doe",
//                PhoneNumber = "829-123-9811",
//                IsActive = true,
//                EmailConfirmed = true,
//                PhoneNumberConfirmed = true,
//                ImageUrl = ".",
//                SecurityStamp = Guid.NewGuid().ToString(),
//                BloodType = "A-",
//                BloodTypeLabResultURl = "http://example.com/lab-results/alice-smith",
//                Height = 165.2m,
//                Weight = 60.8m,
//                EmergencyContactName = "Bob Smith",
//                EmergencyContactPhone = "987-654-3210",
//            },
//            new Patient {
//                Id = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
//                UserName = "patient",
//                Email = "patientuser@email.com",
//                CardId = "40211608648",
//                FirstName = "Alice",
//                LastName = "Smith",
//                PhoneNumber = "829-123-9811",
//                IsActive = true,
//                EmailConfirmed = true,
//                PhoneNumberConfirmed = true,
//                ImageUrl = ".",
//                SecurityStamp = Guid.NewGuid().ToString(),
//                BloodType = "O+",
//                BloodTypeLabResultURl = "http://example.com/lab-results/john-doe",
//                Height = 180.5m,
//                Weight = 75.3m,
//                EmergencyContactName = "Jane Doe",
//                EmergencyContactPhone = "123-456-7890",
//            }
//        };

//        foreach (var patientUser in patientUsers)
//        {
//            var user = await userManager.Users.FirstOrDefaultAsync(u => u.CardId.Equals(patientUser.CardId));
//            if (user == null)
//            {
//                await userManager.CreateAsync(patientUser, "Pa$$w0rddddd");
//                await userManager.AddToRoleAsync(user, RolesEnum.Patient.ToString());
//            }
//        }
//    }
//}
