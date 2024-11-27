using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;

public interface IPatientMedicationPrescriptionRepository : IGenericRelationalRepository<PatientMedicationPrescription>
{
    Task<IEnumerable<PatientMedicationPrescription>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientMedicationPrescription>> GetByMedication(Guid medicationId, bool trackChanges);
    Task<IEnumerable<PatientMedicationPrescription>> GetByMedicalConsultation(Guid medicalConsultationId, bool trackChanges);
}
