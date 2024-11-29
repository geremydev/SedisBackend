using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.MedicalConsultation;

namespace SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;

public interface IMedicalConsultationRepository : IGenericRepository<MedicalConsultation>
{
    Task<IEnumerable<MedicalConsultation>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<MedicalConsultation>> GetByDoctor(Guid doctorId, bool trackChanges);
}
