using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Domain.Clinical_History;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;

namespace SedisBackend.Infrastructure.Persistence.Repositories.Medical_History
{
    public class AllergyRepository : GenericRepository<Allergy>, IAllergyRepository
    {
        public AllergyRepository(SedisContext context) : base(context)
        {
        }
    }
}
