using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Allergies
{
    public class PatientAllergyRepository : GenericRepository<PatientAllergy>, IPatientAllergyRepository
    {
        public PatientAllergyRepository(SedisContext context) : base(context)
        {
        }
    }
}
