using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
public interface IPatientLabTestPrescriptionRepository : IGenericRelationalRepository<PatientLabTestPrescription>
{
    Task<IEnumerable<PatientLabTestPrescription>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByLabTestPrescription(Guid labtestPrescriptionId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByLabTech(Guid labtechId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByDoctor(Guid doctorId, bool trackChanges);
}
