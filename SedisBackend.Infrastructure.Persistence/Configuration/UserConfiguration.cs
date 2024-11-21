using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

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
                Email = "adminuser@email.com",
                PhoneNumber = "829-143-9811",
                Sex = SexEnum.M,
                IsActive = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "YourPassword123!"),
            },
            new User
            {
                Id = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                UserName = "patient",
                Email = "patientuser@email.com",
                CardId = "40211608641",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "829-163-9811",
                IsActive = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                Sex = SexEnum.M,
                PasswordHash = passwordHasher.HashPassword(null, "YourPassword123!"),
            },
            new User
            {
                Id = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                UserName = "patient2",
                Email = "patient2@email.com",
                CardId = "40211608648",
                FirstName = "Alice",
                LastName = "Smith",
                PhoneNumber = "829-128-9811",
                IsActive = true,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                Sex = SexEnum.F,
                PasswordHash = passwordHasher.HashPassword(null, "YourPassword123!"),
            },
            new User
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                UserName = "assistantuser",
                Email = "assistantuser@email.com",
                FirstName = "Ana",
                LastName = "Martínez",
                CardId = "0987634321",
                Birthdate = new DateTime(1995, 12, 1),
                Sex = SexEnum.F,
                PhoneNumber = "829-123-9811",
                IsActive = false,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "YourPassword123!"),
            },
            new User
            {
                Id = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                FirstName = "John",
                LastName = "Doe",
                CardId = "40211608640",
                IsActive = true,
                Birthdate = new DateTime(1980, 5, 15),
                Sex = SexEnum.M,
                UserName = "doctoruser",
                Email = "doctoruser@email.com",
                PhoneNumber = "829-123-9812",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "YourPassword123!"),
            },
            new User
            {
                Id = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                UserName = "doctoruser2",
                Email = "doctoruser2@email.com",
                FirstName = "Jane",
                LastName = "Smith",
                CardId = "0987654321",
                IsActive = false,
                Birthdate = new DateTime(1975, 12, 1),
                Sex = SexEnum.F,
                PhoneNumber = "829-123-9231",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                ImageUrl = ".",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "YourPassword123!"),
            }
        );
    }
}
