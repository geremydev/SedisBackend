using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Appointments;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Health_Centers;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Locations;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Allergies;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Family_History;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Vaccines;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Presctiprions;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.ICD11;

namespace SedisBackend.Core.Application.Interfaces.Services
{
    public interface IServiceManager
    {
        IICD11Service ICD11 { get; } 

        IAppointmentService Appointment { get; }
        IHealthCenterService HealthCenter { get; }
        IHealthCenterServicesService HealthCenterServices { get; }
        ILocationService Location { get; }
        IPrescriptionService Prescription { get; }
        IUserEntityRelationService UserEntityRelation { get; }
        IAllergyService Allergy { get; }
        IPatientAllergyService PatientAllergy { get; }
        IClinicalHistoryService ClinicalHistory { get; }
        IFamilyHistoryService FamilyHistory { get; }
        IVaccineService Vaccine { get; }
        IDiscapacityService Discapacity { get; }
        IPatientDiscapacityService PatientDiscapacity { get; }
        IIllnessService Illness { get; }
        IPatientIllnessService PatientIllness { get; }
        IRiskFactorService RiskFactor { get; }
        IPatientRiskFactorService PatientRiskFactor { get; }
        IHealthInsuranceService HealthInsurance { get; }
        IMedicationCoverageService MedicationCoverage { get; }
        IPatientHealthInsuranceService PatientHealthInsurance { get; }
        ILabTestService LabTest { get; }
        ILabTestPrescriptionService LabTestPrescription { get; }
        IMedicationService Medication { get; }
        IMedicationPrescriptionService MedicationPrescription { get; }
        IAdminService Admin { get; }
        IAssistantService Assistant { get; }
        IDoctorService Doctor { get; }
        IDoctorMedicalSpecialtyService DoctorMedicalSpecialty { get; }
        IDoctorHealthCenterService doctorHealthCenter { get; }
        IMedicalSpecialtyService MedicalSpecialty { get; }
        IPatientService Patient { get; }
    }
}
