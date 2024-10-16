using SedisBackend.Core.Application.Interfaces.Repositories.Appointments;
using SedisBackend.Core.Application.Interfaces.Repositories.Health_Centers;
using SedisBackend.Core.Application.Interfaces.Repositories.ICD11;
using SedisBackend.Core.Application.Interfaces.Repositories.Locations;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Allergies;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Repositories.Prescriptions;
using SedisBackend.Core.Application.Interfaces.Repositories.Products;
using SedisBackend.Core.Application.Interfaces.Repositories.UserEntityRelations;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Repositories.Users.Patients;

namespace SedisBackend.Core.Application.Interfaces.Repositories
{
    public interface IRepositoryManager
    {

        // ICD11 Repository
        IICD11Repository ICD11 { get; }

        IAppointmentRepository Appointment { get; }
        IHealthCenterRepository HealthCenter { get; }
        IHealthCenterServicesRepository HealthCenterServices { get; }
        ILocationRepository Location { get; }
        IUserEntityRelationRepository UserEntityRelation { get; }

        // Medical History
        IAllergyRepository Allergy { get; }
        IPatientAllergyRepository PatientAllergy { get; }
        IClinicalHistoryRepository ClinicalHistory { get; }
        IFamilyHistoryRepository FamilyHistory { get; }
        IVaccineRepository Vaccine{ get; }

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
        ILabTestPrescriptionRepository LabTestPrescription { get; }
        IMedicationPrescriptionRepository MedicationPrescription { get; }
        IPrescriptionRepository Prescription { get; }

        // Products
        ILabTestRepository LabTest { get; }
        IMedicationRepository Medication { get; }

        // Users
        IAdminRepository Admin { get; }
        IAssistantRepository Assistant { get; }
        IDoctorRepository Doctor { get; }
        IDoctorMedicalSpecialtyRepository DoctorMedicalSpecialty { get; }
        IDoctorHealthCenterRepository DoctorHealthCenter { get; }
        IMedicalSpecialtyRepository MedicalSpecialty { get; }
        IPatientRepository Patient { get; }

        Task SaveAsync();
    }
}
