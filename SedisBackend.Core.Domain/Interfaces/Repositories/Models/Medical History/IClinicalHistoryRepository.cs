using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;

public interface IClinicalHistoryRepository : IGenericRepository<MedicalConsultation>
{
}
