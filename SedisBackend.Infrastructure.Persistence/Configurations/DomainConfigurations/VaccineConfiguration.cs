using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Infrastructure.Persistence.Configurations.DomainConfigurations;

public class VaccineConfiguration : IEntityTypeConfiguration<Vaccine>
{
    public void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.HasData
        (
            new Vaccine
            {
                Id = Guid.Parse("f34f7e89-f2f3-4c1d-e0f4-7890b1c2d345"),
                Name = "Vacuna contra el tétanos",
                Doses = 1,
                Laboratory = "GlaxoSmithKline",
                PatientVaccines = new List<PatientVaccine>()
            },
            new Vaccine
            {
                Id = Guid.Parse("123f8e90-f3f4-4d2e-f1f5-8901c2d3e456"),
                Name = "Vacuna contra el sarampión",
                Doses = 2,
                Laboratory = "Merck",
                PatientVaccines = new List<PatientVaccine>()
            },
            new Vaccine
            {
                Id = Guid.Parse("234f9e01-f4f5-4e3f-f2f6-9012d3e4f567"),
                Name = "Vacuna contra la hepatitis B",
                Doses = 3,
                Laboratory = "Sanofi Pasteur",
                PatientVaccines = new List<PatientVaccine>()
            },
            new Vaccine
            {
                Id = Guid.Parse("345f0e12-f5f6-4f4f-f3f7-a012e4f5g678"),
                Name = "Vacuna contra la varicela",
                Doses = 2,
                Laboratory = "Pfizer",
                PatientVaccines = new List<PatientVaccine>()
            },
            new Vaccine
            {
                Id = Guid.Parse("456f1e23-f6f7-504f-f4f8-b123f5g6h789"),
                Name = "Vacuna contra el VPH",
                Doses = 2,
                Laboratory = "Merck",
                PatientVaccines = new List<PatientVaccine>()
            }
        );
    }
}
