using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Infrastructure.Persistence.Configuration
{
    public class MedicalSpecialtyConfiguration : IEntityTypeConfiguration<MedicalSpecialty>
    {
        public void Configure(EntityTypeBuilder<MedicalSpecialty> builder)
        {
            builder.HasData
            (
                new MedicalSpecialty
                {
                    Id = Guid.Parse("f1a2b3c4-d5e6-789f-0123-456789abcdef"),
                    Name = "Cardiology", // Enum 
                    Description = "Specializes in the treatment of heart conditions."
                },
                new MedicalSpecialty
                {
                    Id = Guid.Parse("a1b2c3d4-e5f6-7890-1234-56789abcdef0"),
                    Name = "Neurology", // Enum 
                    Description = "Focuses on the diagnosis and treatment of neurological disorders."
                }
            );
        }
    }
}
