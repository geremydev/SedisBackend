using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Infrastructure.Persistence.Configuration;

public class HealthInsuranceConfiguration : IEntityTypeConfiguration<HealthInsurance>
{
    public void Configure(EntityTypeBuilder<HealthInsurance> builder)
    {
        builder.HasData
        (
            new HealthInsurance
            {
                Id = Guid.Parse("b51ec3f9-bdc8-4a74-b43e-bf4da6e2f9b9"),
                InsuranceName = "Seguro Salud Total",
                PolicyType = PolicyType.Individual.ToString(),
                InsuranceCompany = "SaludCo",
                CoverageLevel = CoverageLevel.Low.ToString(),
                MedicationCoverages = new List<MedicationCoverage>(),
                SubscribedPatients = new List<PatientHealthInsurance>()
            },
            new HealthInsurance
            {
                Id = Guid.Parse("7f5d5339-9de6-4ab0-b43c-d6b3d43e4d80"),
                InsuranceName = "Plan Familiar Salud",
                PolicyType = PolicyType.Family.ToString(),
                InsuranceCompany = "VivaSalud",
                CoverageLevel = CoverageLevel.High.ToString(),
                MedicationCoverages = new List<MedicationCoverage>(),
                SubscribedPatients = new List<PatientHealthInsurance>()
            }
        );
    }
}

