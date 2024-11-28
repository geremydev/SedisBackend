using Microsoft.EntityFrameworkCore.Storage;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Shared;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;

namespace SedisBackend.Core.Domain.Interfaces.Repositories;

public interface IRepositoryManager
{
    // ICD11 Repository
    IICD11Repository ICD11 { get; }

    IHealthCenterRepository HealthCenter { get; }
    IHealthCenterServicesRepository HealthCenterServices { get; }
    ILocationRepository Location { get; }
    IUserEntityRelationRepository UserEntityRelation { get; }

    // Medical History
    IAllergyRepository Allergy { get; }
    IPatientAllergyRepository PatientAllergy { get; }
    IMedicalConsultationRepository MedicalConsultation { get; }
    IFamilyHistoryRepository FamilyHistory { get; }
    IVaccineRepository Vaccine { get; }

    // Medical Conditions
    IDiscapacityRepository Discapacity { get; }
    IPatientDiscapacityRepository PatientDiscapacity { get; }
    IIllnessRepository Illness { get; }
    IPatientIllnessRepository PatientIllness { get; }
    IRiskFactorRepository RiskFactor { get; }
    IPatientRiskFactorRepository PatientRiskFactor { get; }

    //  Medical Insurance
    IHealthInsuranceRepository HealthInsurance { get; }
    IMedicationCoverageRepository MedicationCoverage { get; }
    IPatientHealthInsuranceRepository PatientHealthInsurance { get; }

    // Prescription
    IPatientMedicationPrescriptionRepository PatientMedicationPrescriptionRepository { get; }
    IPatientLabTestPrescriptionRepository PatientLabTestPrescription { get; }
    // Products
    ILabTestRepository LabTest { get; }
    IMedicationRepository Medication { get; }

    // Users
    IAdminRepository Admin { get; }
    IAssistantRepository Assistant { get; }
    IDoctorRepository Doctor { get; }
    IDoctorMedicalSpecialtyRepository DoctorMedicalSpecialty { get; }
    IMedicalSpecialtyRepository MedicalSpecialty { get; }
    IPatientRepository Patient { get; }
    ILabTechRepository LabTech { get; }
    IRegistratorRepository Registrator { get; }

    IAppointmentRepository Appointment { get; }

    Task SaveAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
