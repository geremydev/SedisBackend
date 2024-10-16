using SedisBackend.Core.Application.Interfaces.Repositories;
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
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.Appointments;
using SedisBackend.Infrastructure.Persistence.Repositories.Health_Centers;
using SedisBackend.Infrastructure.Persistence.Repositories.ICD11;
using SedisBackend.Infrastructure.Persistence.Repositories.Locations;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_History;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Allergies;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_History.Medical_Conditions.Risk_Factor_Condition;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_Insurance;
using SedisBackend.Infrastructure.Persistence.Repositories.Presctiption;
using SedisBackend.Infrastructure.Persistence.Repositories.Products;
using SedisBackend.Infrastructure.Persistence.Repositories.UserEntityRelations;
using SedisBackend.Infrastructure.Persistence.Repositories.Users.Admins;
using SedisBackend.Infrastructure.Persistence.Repositories.Users.Assistants;
using SedisBackend.Infrastructure.Persistence.Repositories.Users.Doctors;
using SedisBackend.Infrastructure.Persistence.Repositories.Users.Patients;

namespace SedisBackend.Infrastructure.Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly SedisContext _repositoryContext;

        private readonly Lazy<IICD11Repository> _icd11Repository;

        private readonly Lazy<IAppointmentRepository> _appointmentRepository;
        private readonly Lazy<IHealthCenterRepository> _healthCenterRepository;
        private readonly Lazy<IHealthCenterServicesRepository> _healthCenterServicesRepository;
        private readonly Lazy<ILocationRepository> _locationRepository;
        private readonly Lazy<IPrescriptionRepository> _prescriptionRepository;
        private readonly Lazy<IUserEntityRelationRepository> _userEntityRelationRepository;
        private readonly Lazy<IAllergyRepository> _allergyRepository;
        private readonly Lazy<IPatientAllergyRepository> _patientAllergyRepository;
        private readonly Lazy<IClinicalHistoryRepository> _clinicalHistoryRepository;
        private readonly Lazy<IFamilyHistoryRepository> _familyHistoryRepository;
        private readonly Lazy<IVaccineRepository> _vaccineRepository;
        private readonly Lazy<IDiscapacityRepository> _discapacityRepository;
        private readonly Lazy<IPatientDiscapacityRepository> _patientDiscapacityRepository;
        private readonly Lazy<IIllnessRepository> _illnessRepository;
        private readonly Lazy<IPatientIllnessRepository> _patientIllnessRepository;
        private readonly Lazy<IRiskFactorRepository> _riskFactorRepository;
        private readonly Lazy<IPatientRiskFactorRepository> _patientRiskFactorRepository;
        private readonly Lazy<IHealthInsuranceRepository> _healthInsuranceRepository;
        private readonly Lazy<IMedicationCoverageRepository> _medicationCoverageRepository;
        private readonly Lazy<IMedicationPrescriptionRepository> _medicationPrescriptionRepository;
        private readonly Lazy<IPatientHealthInsuranceRepository> _patientHealthInsuranceRepository;
        private readonly Lazy<ILabTestRepository> _labTestRepository;
        private readonly Lazy<ILabTestPrescriptionRepository> _labTestPrescriptionRepository;
        private readonly Lazy<IMedicationRepository> _medicationRepository;
        private readonly Lazy<IAdminRepository> _adminRepository;
        private readonly Lazy<IAssistantRepository> _assistantRepository;
        private readonly Lazy<IDoctorRepository> _doctorRepository;
        private readonly Lazy<IDoctorMedicalSpecialtyRepository> _doctorMedicalSpecialtyRepository;
        private readonly Lazy<IDoctorHealthCenterRepository> _doctorHealthCenterRepository;
        private readonly Lazy<IMedicalSpecialtyRepository> _medicalSpecialtyRepository;
        private readonly Lazy<IPatientRepository> _patientRepository;

        public RepositoryManager(SedisContext repositoryContext, HttpClient httpClient)
        {
            _repositoryContext = repositoryContext;

            _icd11Repository = new Lazy<IICD11Repository>(() => new ICD11Repository(httpClient));

            _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));
            _healthCenterRepository = new Lazy<IHealthCenterRepository>(() => new HealthCenterRepository(repositoryContext));
            _healthCenterServicesRepository = new Lazy<IHealthCenterServicesRepository>(() => new HealthCenterServicesRepository(repositoryContext));
            _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
            _prescriptionRepository = new Lazy<IPrescriptionRepository>(() => new PrescriptionRepository(repositoryContext));
            _userEntityRelationRepository = new Lazy<IUserEntityRelationRepository>(() => new UserEntityRelationRepository(repositoryContext));
            _allergyRepository = new Lazy<IAllergyRepository>(() => new AllergyRepository(repositoryContext));
            _patientAllergyRepository = new Lazy<IPatientAllergyRepository>(() => new PatientAllergyRepository(repositoryContext));
            _clinicalHistoryRepository = new Lazy<IClinicalHistoryRepository>(() => new ClinicalHistoryRepository(repositoryContext));
            _familyHistoryRepository = new Lazy<IFamilyHistoryRepository>(() => new FamilyHistoryRepository(repositoryContext));
            _vaccineRepository = new Lazy<IVaccineRepository>(() => new VaccineRepository(repositoryContext));
            _discapacityRepository = new Lazy<IDiscapacityRepository>(() => new DiscapacityRepository(repositoryContext));
            _patientDiscapacityRepository = new Lazy<IPatientDiscapacityRepository>(() => new PatientDiscapacityRepository(repositoryContext));
            _illnessRepository = new Lazy<IIllnessRepository>(() => new IllnessRepository(repositoryContext));
            _patientIllnessRepository = new Lazy<IPatientIllnessRepository>(() => new PatientIllnessRepository(repositoryContext));
            _riskFactorRepository = new Lazy<IRiskFactorRepository>(() => new RiskFactorRepository(repositoryContext));
            _patientRiskFactorRepository = new Lazy<IPatientRiskFactorRepository>(() => new PatientRiskFactorRepository(repositoryContext));
            _healthInsuranceRepository = new Lazy<IHealthInsuranceRepository>(() => new HealthInsuranceRepository(repositoryContext));
            _medicationCoverageRepository = new Lazy<IMedicationCoverageRepository>(() => new MedicationCoverageRepository(repositoryContext));
            _patientHealthInsuranceRepository = new Lazy<IPatientHealthInsuranceRepository>(() => new PatientHealthInsuranceRepository(repositoryContext));
            _labTestRepository = new Lazy<ILabTestRepository>(() => new LabTestRepository(repositoryContext));
            _labTestPrescriptionRepository = new Lazy<ILabTestPrescriptionRepository>(() => new LabTestPrescriptionRepository(repositoryContext));
            _medicationRepository = new Lazy<IMedicationRepository>(() => new MedicationRepository(repositoryContext));
            _medicationPrescriptionRepository = new Lazy<IMedicationPrescriptionRepository>(() => new MedicationPrescriptionRepository(repositoryContext));
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(repositoryContext));
            _assistantRepository = new Lazy<IAssistantRepository>(() => new AssistantRepository(repositoryContext));
            _doctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(repositoryContext));
            _doctorHealthCenterRepository = new Lazy<IDoctorHealthCenterRepository>(() => new DoctorHealthCenterRepository(repositoryContext));
            _doctorMedicalSpecialtyRepository = new Lazy<IDoctorMedicalSpecialtyRepository>(() => new DoctorMedicalSpecialtyRepository(repositoryContext));
            _medicalSpecialtyRepository = new Lazy<IMedicalSpecialtyRepository>(() => new MedicalSpecialtyRepository(repositoryContext));
            _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(repositoryContext));
        }

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public IICD11Repository ICD11 => _icd11Repository.Value;

        public IAppointmentRepository Appointment => _appointmentRepository.Value;
        public IHealthCenterRepository HealthCenter => _healthCenterRepository.Value;
        public IHealthCenterServicesRepository HealthCenterServices => _healthCenterServicesRepository.Value;
        public ILocationRepository Location => _locationRepository.Value;
        public IPrescriptionRepository Prescription => _prescriptionRepository.Value;
        public IUserEntityRelationRepository UserEntityRelation => _userEntityRelationRepository.Value;
        public IAllergyRepository Allergy => _allergyRepository.Value;
        public IPatientAllergyRepository PatientAllergy => _patientAllergyRepository.Value;
        public IClinicalHistoryRepository ClinicalHistory => _clinicalHistoryRepository.Value;
        public IFamilyHistoryRepository FamilyHistory => _familyHistoryRepository.Value;
        public IVaccineRepository Vaccine => _vaccineRepository.Value;
        public IDiscapacityRepository Discapacity => _discapacityRepository.Value;
        public IPatientDiscapacityRepository PatientDiscapacity => _patientDiscapacityRepository.Value;
        public IIllnessRepository Illness => _illnessRepository.Value;
        public IPatientIllnessRepository PatientIllness => _patientIllnessRepository.Value;
        public IRiskFactorRepository RiskFactor => _riskFactorRepository.Value;
        public IPatientRiskFactorRepository PatientRiskFactor => _patientRiskFactorRepository.Value;
        public IHealthInsuranceRepository HealthInsurance => _healthInsuranceRepository.Value;
        public IMedicationCoverageRepository MedicationCoverage => _medicationCoverageRepository.Value;
        public IMedicationPrescriptionRepository MedicationPrescription => _medicationPrescriptionRepository.Value;
        public IPatientHealthInsuranceRepository PatientHealthInsurance => _patientHealthInsuranceRepository.Value;
        public ILabTestRepository LabTest => _labTestRepository.Value;
        public ILabTestPrescriptionRepository LabTestPrescription => _labTestPrescriptionRepository.Value;
        public IMedicationRepository Medication => _medicationRepository.Value;
        public IAdminRepository Admin => _adminRepository.Value;
        public IAssistantRepository Assistant => _assistantRepository.Value;
        public IDoctorRepository Doctor => _doctorRepository.Value;
        public IDoctorHealthCenterRepository DoctorHealthCenter => _doctorHealthCenterRepository.Value;
        public IDoctorMedicalSpecialtyRepository DoctorMedicalSpecialty => _doctorMedicalSpecialtyRepository.Value;
        public IMedicalSpecialtyRepository MedicalSpecialty => _medicalSpecialtyRepository.Value;
        public IPatientRepository Patient => _patientRepository.Value;
    }
}
