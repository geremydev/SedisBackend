using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Infrastructure.Persistence.Configuration.UsersConfiguration;
internal class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasData
        (
            new Patient
            {
                Id = Guid.Parse("c7f1d0d1-2b5f-4e77-a2a8-4b5d06d75950"),
                BloodType = "A+",
                BloodTypeLabResultURl = "http://example.com/lab-results/mark-abreu",
                Height = 172.5m,
                Weight = 70.0m,
                EmergencyContactName = "Maria Abreu",
                EmergencyContactPhone = "809-123-4567",
            },
            new Patient
            {
                Id = Guid.Parse("d8e2f93f-3b9f-4b88-981f-56eaa8ddc3e9"),
                BloodType = "O-",
                BloodTypeLabResultURl = "http://example.com/lab-results/alice-smith",
                Height = 160.3m,
                Weight = 55.0m,
                EmergencyContactName = "John Smith",
                EmergencyContactPhone = "809-987-6543",
            },
            new Patient
            {
                Id = Guid.Parse("ea48eb4c-01c4-44d2-a81f-fc9246d2ec20"),
                BloodType = "B+",
                BloodTypeLabResultURl = "http://example.com/lab-results/geremy-ferran",
                Height = 175.8m,
                Weight = 78.5m,
                EmergencyContactName = "Ana Ferrán",
                EmergencyContactPhone = "829-123-1111",
            },
            new Patient
            {
                Id = Guid.Parse("f86a1609-cb84-4d6a-8d8a-8e49b6b9a5b9"),
                BloodType = "AB+",
                BloodTypeLabResultURl = "http://example.com/lab-results/brahiam-montero",
                Height = 182.0m,
                Weight = 85.2m,
                EmergencyContactName = "Luis Montero",
                EmergencyContactPhone = "829-222-3333",
            },
            new Patient
            {
                Id = Guid.Parse("37439d05-9b3b-4896-88e0-4ee7b7221a8b"),
                BloodType = "O+",
                BloodTypeLabResultURl = "http://example.com/lab-results/ana-martinez",
                Height = 165.0m,
                Weight = 60.0m,
                EmergencyContactName = "John Martinez",
                EmergencyContactPhone = "829-123-9811",
            },
            new Patient
            {
                Id = Guid.Parse("b2f7d5b4-2f4d-4b2b-a292-1b9b65d5d6c0"),
                BloodType = "A+",
                BloodTypeLabResultURl = "http://example.com/lab-results/isaac-polonio",
                Height = 180.0m,
                Weight = 85.0m,
                EmergencyContactName = "Alex Polonio",
                EmergencyContactPhone = "829-123-9812",
            },
            new Patient
            {
                Id = Guid.Parse("e9f7a7e1-f0d2-4f2c-bcb9-3e1a5a7a1e0b"),
                BloodType = "B-",
                BloodTypeLabResultURl = "http://example.com/lab-results/layla-vargas",
                Height = 162.0m,
                Weight = 58.0m,
                EmergencyContactName = "Sophia Vargas",
                EmergencyContactPhone = "829-123-9231",
            },
            new Patient
            {
                Id = Guid.Parse("83d48d7c-6a56-4233-9934-9d30bde63bb5"),
                BloodType = "AB+",
                BloodTypeLabResultURl = "http://example.com/lab-results/maria-lopez",
                Height = 170.0m,
                Weight = 65.0m,
                EmergencyContactName = "Ana Lopez",
                EmergencyContactPhone = "809-987-6543",
            },
            new Patient
            {
                Id = Guid.Parse("9c87b12f-d892-4f2b-8e2c-5347c8c1b056"),
                BloodType = "O-",
                BloodTypeLabResultURl = "http://example.com/lab-results/carlos-gonzalez",
                Height = 178.0m,
                Weight = 80.0m,
                EmergencyContactName = "Luis Gonzalez",
                EmergencyContactPhone = "809-234-5678",
            },
            new Patient
            {
                Id = Guid.Parse("b7e1e44d-72c9-4c91-a933-9e4f0e6b5f11"),
                BloodType = "A-",
                BloodTypeLabResultURl = "http://example.com/lab-results/ana-martinez",
                Height = 165.0m,
                Weight = 60.0m,
                EmergencyContactName = "John Martinez",
                EmergencyContactPhone = "809-876-5432",
            },
            new Patient
            {
                Id = Guid.Parse("e2a4d5b6-3c9a-47bc-8db1-cd327a2f92d6"),
                BloodType = "B+",
                BloodTypeLabResultURl = "http://example.com/lab-results/luis-santos",
                Height = 172.0m,
                Weight = 78.0m,
                EmergencyContactName = "Carlos Santos",
                EmergencyContactPhone = "809-321-9876",
            }
        );
    }
}
