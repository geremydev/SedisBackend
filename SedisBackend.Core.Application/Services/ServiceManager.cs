using AutoMapper;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Application.Interfaces.Services;
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
using SedisBackend.Core.Application.Services.Domain_Services.Appointments;
using SedisBackend.Core.Application.Services.Domain_Services.Health_Centers;
using SedisBackend.Core.Application.Services.Domain_Services.Locations;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Allergies;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Family_History;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Vaccines;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Services.Domain_Services.Prescriptions;
using SedisBackend.Core.Application.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Admins;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Assistants;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Services.ICD;

namespace SedisBackend.Core.Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IICD11Service> _icd11Service;

        private readonly Lazy<IAppointmentService> _appointmentService;
        private readonly Lazy<IHealthCenterService> _healthCenterService;
        private readonly Lazy<IHealthCenterServicesService> _healthCenterServicesService;
        private readonly Lazy<ILocationService> _locationService;
        private readonly Lazy<IPrescriptionService> _prescriptionService;
        private readonly Lazy<IUserEntityRelationService> _userEntityRelationService;
        private readonly Lazy<IAllergyService> _allergyService;
        private readonly Lazy<IPatientAllergyService> _patientAllergyService;
        private readonly Lazy<IClinicalHistoryService> _clinicalHistoryService;
        private readonly Lazy<IFamilyHistoryService> _familyHistoryService;
        private readonly Lazy<IVaccineService> _vaccineService;
        private readonly Lazy<IDiscapacityService> _discapacityService;
        private readonly Lazy<IPatientDiscapacityService> _patientDiscapacityService;
        private readonly Lazy<IIllnessService> _illnessService;
        private readonly Lazy<IPatientIllnessService> _patientIllnessService;
        private readonly Lazy<IRiskFactorService> _riskFactorService;
        private readonly Lazy<IPatientRiskFactorService> _patientRiskFactorService;
        private readonly Lazy<IHealthInsuranceService> _healthInsuranceService;
        private readonly Lazy<IMedicationCoverageService> _medicationCoverageService;
        private readonly Lazy<IMedicationPrescriptionService> _medicationPrescriptionService;
        private readonly Lazy<IPatientHealthInsuranceService> _patientHealthInsuranceService;
        private readonly Lazy<ILabTestService> _labTestService;
        private readonly Lazy<ILabTestPrescriptionService> _labTestPrescriptionService;
        private readonly Lazy<IMedicationService> _medicationService;
        private readonly Lazy<IAdminService> _adminService;
        private readonly Lazy<IAssistantService> _assistantService;
        private readonly Lazy<IDoctorService> _doctorService;
        private readonly Lazy<IDoctorHealthCenterService> _doctorHealthCenterService;
        private readonly Lazy<IDoctorMedicalSpecialtyService> _doctorMedicalSpecialtyService;
        private readonly Lazy<IMedicalSpecialtyService> _medicalSpecialtyService;
        private readonly Lazy<IPatientService> _patientService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerManager logger,
            IMapper mapper)
        {
            _icd11Service = new Lazy<IICD11Service>(() =>
                new ICD11Service(repositoryManager.ICD11, logger));

            _appointmentService = new Lazy<IAppointmentService>(() =>
                new AppointmentService(repositoryManager.Appointment, logger, mapper));
            _healthCenterService = new Lazy<IHealthCenterService>(() =>
                new HealthCenterService(repositoryManager.HealthCenter, logger, mapper));
            _healthCenterServicesService = new Lazy<IHealthCenterServicesService>(() =>
                new HealthCenterServicesService(repositoryManager.HealthCenterServices, logger, mapper));
            _locationService = new Lazy<ILocationService>(() =>
                new LocationService(repositoryManager.Location, logger, mapper));
            _prescriptionService = new Lazy<IPrescriptionService>(() =>
                new PrescriptionService(repositoryManager.Prescription, logger, mapper));
            _userEntityRelationService = new Lazy<IUserEntityRelationService>(() =>
                new UserEntityRelationService(repositoryManager.UserEntityRelation, logger, mapper));
            _allergyService = new Lazy<IAllergyService>(() =>
                new AllergyService(repositoryManager.Allergy, logger, mapper));
            _patientAllergyService = new Lazy<IPatientAllergyService>(() =>
                new PatientAllergyService(repositoryManager.PatientAllergy, logger, mapper));
            _clinicalHistoryService = new Lazy<IClinicalHistoryService>(() =>
                new ClinicalHistoryService(repositoryManager.ClinicalHistory, logger, mapper));
            _familyHistoryService = new Lazy<IFamilyHistoryService>(() =>
                new FamilyHistoryService(repositoryManager.FamilyHistory, logger, mapper));
            _vaccineService = new Lazy<IVaccineService>(() =>
                new VaccineService(repositoryManager.Vaccine, logger, mapper));
            _discapacityService = new Lazy<IDiscapacityService>(() =>
                new DiscapacityService(repositoryManager.Discapacity, logger, mapper));
            _patientDiscapacityService = new Lazy<IPatientDiscapacityService>(() =>
                new PatientDiscapacityService(repositoryManager.PatientDiscapacity, logger, mapper));
            _illnessService = new Lazy<IIllnessService>(() =>
                new IllnessService(repositoryManager.Illness, logger, mapper));
            _patientIllnessService = new Lazy<IPatientIllnessService>(() =>
                new PatientIllnessService(repositoryManager.PatientIllness, logger, mapper));
            _riskFactorService = new Lazy<IRiskFactorService>(() =>
                new RiskFactorService(repositoryManager.RiskFactor, logger, mapper));
            _patientRiskFactorService = new Lazy<IPatientRiskFactorService>(() =>
                new PatientRiskFactorService(repositoryManager.PatientRiskFactor, logger, mapper));
            _healthInsuranceService = new Lazy<IHealthInsuranceService>(() =>
                new HealthInsuranceService(repositoryManager.HealthInsurance, logger, mapper));
            _medicationCoverageService = new Lazy<IMedicationCoverageService>(() =>
                new MedicationCoverageService(repositoryManager.MedicationCoverage, logger, mapper));
            _medicationPrescriptionService = new Lazy<IMedicationPrescriptionService>(() =>
                new MedicationPrescriptionService(repositoryManager.MedicationPrescription, logger, mapper));
            _patientHealthInsuranceService = new Lazy<IPatientHealthInsuranceService>(() =>
                new PatientHealthInsuranceService(repositoryManager.PatientHealthInsurance, logger, mapper));
            _labTestService = new Lazy<ILabTestService>(() =>
                new LabTestService(repositoryManager.LabTest, logger, mapper));
            _labTestPrescriptionService = new Lazy<ILabTestPrescriptionService>(() =>
                new LabTestPrescriptionService(repositoryManager.LabTestPrescription, logger, mapper));
            _medicationService = new Lazy<IMedicationService>(() =>
                new MedicationService(repositoryManager.Medication, logger, mapper));
            _adminService = new Lazy<IAdminService>(() =>
                new AdminService(repositoryManager.Admin, logger, mapper));
            _assistantService = new Lazy<IAssistantService>(() =>
                new AssistantService(repositoryManager.Assistant, logger, mapper));
            _doctorService = new Lazy<IDoctorService>(() =>
                new DoctorService(repositoryManager.Doctor, logger, mapper));
            _doctorHealthCenterService = new Lazy<IDoctorHealthCenterService>(() =>
                new DoctorHealthCenterService(repositoryManager.DoctorHealthCenter, logger, mapper));
            _doctorMedicalSpecialtyService = new Lazy<IDoctorMedicalSpecialtyService>(() =>
                new DoctorMedicalSpecialtyService(repositoryManager.DoctorMedicalSpecialty, logger, mapper));
            _medicalSpecialtyService = new Lazy<IMedicalSpecialtyService>(() =>
                new MedicalSpecialtyService(repositoryManager.MedicalSpecialty, logger, mapper));
            _patientService = new Lazy<IPatientService>(() =>
                new PatientService(repositoryManager.Patient, logger, mapper));
        }

        public IICD11Service ICD11 => _icd11Service.Value;

        public IAppointmentService Appointment => _appointmentService.Value;
        public IHealthCenterService HealthCenter => _healthCenterService.Value;
        public IHealthCenterServicesService HealthCenterServices => _healthCenterServicesService.Value;
        public ILocationService Location => _locationService.Value;
        public IPrescriptionService Prescription => _prescriptionService.Value;
        public IUserEntityRelationService UserEntityRelation => _userEntityRelationService.Value;
        public IAllergyService Allergy => _allergyService.Value;
        public IPatientAllergyService PatientAllergy => _patientAllergyService.Value;
        public IClinicalHistoryService ClinicalHistory => _clinicalHistoryService.Value;
        public IFamilyHistoryService FamilyHistory => _familyHistoryService.Value;
        public IVaccineService Vaccine => _vaccineService.Value;
        public IDiscapacityService Discapacity => _discapacityService.Value;
        public IPatientDiscapacityService PatientDiscapacity => _patientDiscapacityService.Value;
        public IIllnessService Illness => _illnessService.Value;
        public IPatientIllnessService PatientIllness => _patientIllnessService.Value;
        public IRiskFactorService RiskFactor => _riskFactorService.Value;
        public IPatientRiskFactorService PatientRiskFactor => _patientRiskFactorService.Value;
        public IHealthInsuranceService HealthInsurance => _healthInsuranceService.Value;
        public IMedicationCoverageService MedicationCoverage => _medicationCoverageService.Value;
        public IMedicationPrescriptionService MedicationPrescription => _medicationPrescriptionService.Value;
        public IPatientHealthInsuranceService PatientHealthInsurance => _patientHealthInsuranceService.Value;
        public ILabTestService LabTest => _labTestService.Value;
        public ILabTestPrescriptionService LabTestPrescription => _labTestPrescriptionService.Value;
        public IMedicationService Medication => _medicationService.Value;
        public IAdminService Admin => _adminService.Value;
        public IAssistantService Assistant => _assistantService.Value;
        public IDoctorService Doctor => _doctorService.Value;
        public IPatientService Patient => _patientService.Value;
        public IDoctorMedicalSpecialtyService DoctorMedicalSpecialty => _doctorMedicalSpecialtyService.Value;
        public IDoctorHealthCenterService doctorHealthCenter => _doctorHealthCenterService.Value;
        public IMedicalSpecialtyService MedicalSpecialty => _medicalSpecialtyService.Value;
    }
}
