using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Configuration.UsersConfiguration;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var passwordHasher = new PasswordHasher<User>();

        builder.HasData
        (
            new User
            {
                Id = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                UserName = "adminuser",
                FirstName = "Brahiam",
                LastName = "Montero",
                CardId = "40211608647",
                Email = "brahiam@sedis.com",
                PhoneNumber = "809-962-2004",
                Sex = SexEnum.M,
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Brahiam123$"),
            },
            new User
            {
                Id = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                UserName = "adminuser",
                FirstName = "Geremy",
                LastName = "Ferrán",
                CardId = "40208899928",
                Email = "geremy@sedis.com",
                PhoneNumber = "829-143-9811",
                Sex = SexEnum.M,
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Geremy123$"),
            },
            new User
            {
                Id = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                UserName = "patient",
                Email = "patient@email.com",
                CardId = "40211608641",
                FirstName = "Mark",
                LastName = "Abreu",
                PhoneNumber = "829-163-9811",
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                Sex = SexEnum.M,
                PasswordHash = passwordHasher.HashPassword(null, "Patient123$"),
            },
            new User
            {
                Id = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                UserName = "patient2",
                Email = "alicepatient@sedis.com",
                CardId = "40211608648",
                FirstName = "Alice",
                LastName = "Smith",
                PhoneNumber = "829-128-9811",
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                Sex = SexEnum.F,
                PasswordHash = passwordHasher.HashPassword(null, "Patient2$"),
            },
            new User
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                UserName = "assistantuser",
                Email = "assistantuser@sedis.com",
                FirstName = "Ana",
                LastName = "Martínez",
                CardId = "0987634321",
                Birthdate = new DateTime(1995, 12, 1),
                Sex = SexEnum.F,
                PhoneNumber = "829-123-9811",
                Status = false,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Assistant123$"),
            },
            // Doctores
            new User
            {
                Id = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                FirstName = "Isaac Alexander",
                LastName = "Polonio",
                CardId = "40211608640",
                Status = true,
                Birthdate = new DateTime(1980, 5, 15),
                Sex = SexEnum.M,
                UserName = "doctor",
                Email = "isaac@sedis.com",
                PhoneNumber = "829-123-9812",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Doctor123$"),
            },
            new User
            {
                Id = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                UserName = "doctor2",
                Email = "layladoc@sedis.com",
                FirstName = "Layla",
                LastName = "Vargas",
                CardId = "0987654321",
                Status = false,
                Birthdate = new DateTime(1975, 12, 1),
                Sex = SexEnum.F,
                PhoneNumber = "829-123-9231",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Doctor2123$"),
            },
            new User
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a5b"),
                UserName = "digitaregistrator",
                Email = "registrator@sedis.com",
                FirstName = "Gilthong Emmanuel",
                LastName = "Palin Garcia",
                CardId = "0587654321",
                Birthdate = new DateTime(1995, 12, 1),
                Sex = SexEnum.M,
                PhoneNumber = "829-123-9312",
                Status = false,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Digitador123$"),
            },
            new User
            {
                Id = Guid.Parse("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                UserName = "registrator_cdm",
                Email = "registrator.cdm@sedis.com",
                FirstName = "Maria",
                LastName = "Lopez",
                CardId = "1122334455",
                Birthdate = new DateTime(1988, 8, 20),
                Sex = SexEnum.F,
                PhoneNumber = "809-987-6543",
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Digitador123$")
            },
            new User
            {
                Id = Guid.Parse("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                UserName = "registrator_union",
                Email = "registrator.union@sedis.com",
                FirstName = "Carlos",
                LastName = "Gonzalez",
                CardId = "3344556677",
                Birthdate = new DateTime(1985, 3, 22),
                Sex = SexEnum.M,
                PhoneNumber = "809-254-5678",
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Digitador123$")
            },
            new User
            {
                Id = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                UserName = "registrator_altagracia",
                Email = "registrator.altagracia@sedis.com",
                FirstName = "Ana",
                LastName = "Martinez",
                CardId = "4455667788",
                Birthdate = new DateTime(1992, 11, 5),
                Sex = SexEnum.F,
                PhoneNumber = "809-876-5432",
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Digitador123$")
            },
            new User
            {
                Id = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                UserName = "registrator_cibao",
                Email = "registrator.cibao@sedis.com",
                FirstName = "Luis",
                LastName = "Santos",
                CardId = "5566778899",
                Birthdate = new DateTime(1980, 7, 30),
                Sex = SexEnum.M,
                PhoneNumber = "809-321-9876",
                Status = false,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Digitador123$")
            },
            // LabTechs
            new User
            {
                Id = Guid.Parse("a3c9e2d7-b43f-44c1-a657-d5e5fa9a5b5c"),
                UserName = "tech1user",
                FirstName = "Carlos",
                LastName = "Perez",
                CardId = "12345678901",
                Email = "carlos@sedis.com",
                PhoneNumber = "809-123-4567",
                Sex = SexEnum.M,
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Tech123$"),
            },
            new User
            {
                Id = Guid.Parse("d8f1e9b3-42a1-44d5-8f3b-6c7a9e5f6d4a"),
                UserName = "tech2user",
                FirstName = "Maria",
                LastName = "Lopez",
                CardId = "98765432101",
                Email = "maria@sedis.com",
                PhoneNumber = "809-234-4678",
                Sex = SexEnum.F,
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Tech456$"),
            },
            new User
            {
                Id = Guid.Parse("b4c3d9e1-2a7f-44c3-a9b1-f5e6c7a8d9f4"),
                UserName = "tech3user",
                FirstName = "Luis",
                LastName = "Gomez",
                CardId = "13579246801",
                Email = "luis@sedis.com",
                PhoneNumber = "809-345-6789",
                Sex = SexEnum.M,
                Status = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Tech789$"),
            }
        );
    }
}
