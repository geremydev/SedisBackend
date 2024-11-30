using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;

public interface IVaccineRepository : IGenericRepository<Vaccine>
{
}
