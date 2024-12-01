using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Users;
public interface ILabTechRepository : IGenericRepository<LabTech>
{
    ICollection<LabTech> GetByHealthCenterId(Guid HealthCenterId);
}
