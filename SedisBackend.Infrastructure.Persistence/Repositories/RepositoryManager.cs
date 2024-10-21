using Microsoft.EntityFrameworkCore.Storage;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Shared;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;

namespace SedisBackend.Infrastructure.Persistence.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly SedisContext _repositoryContext;

    private readonly Lazy<IICD11Repository> _icd11Repository;

    private readonly Lazy<IAppointmentRepository> _appointmentRepository;
    private readonly Lazy<ILabTestRepository> _labtestRepository;
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
    private readonly Lazy<IAppointmentPrescriptionRepository> _appointmentPrescriptionRepository;
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

        //_icd11Repository = new Lazy<IICD11Repository>(() => new ICD11Repository(httpClient));

        _labtestRepository = new Lazy<ILabTestRepository>(() => new LabTestRepository(repositoryContext));
        _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));
        _healthCenterRepository = new Lazy<IHealthCenterRepository>(() => new HealthCenterRepository(repositoryContext));
        _healthCenterServicesRepository = new Lazy<IHealthCenterServicesRepository>(() => new HealthCenterServicesRepository(repositoryContext));
        _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
        _prescriptionRepository = new Lazy<IPrescriptionRepository>(() => new PrescriptionRepository(repositoryContext));
        _allergyRepository = new Lazy<IAllergyRepository>(() => new AllergyRepository(repositoryContext));
        _clinicalHistoryRepository = new Lazy<IClinicalHistoryRepository>(() => new ClinicalHistoryRepository(repositoryContext));
        _familyHistoryRepository = new Lazy<IFamilyHistoryRepository>(() => new FamilyHistoryRepository(repositoryContext));
        _vaccineRepository = new Lazy<IVaccineRepository>(() => new VaccineRepository(repositoryContext));
        _discapacityRepository = new Lazy<IDiscapacityRepository>(() => new DiscapacityRepository(repositoryContext));
        _illnessRepository = new Lazy<IIllnessRepository>(() => new IllnessRepository(repositoryContext));
        _riskFactorRepository = new Lazy<IRiskFactorRepository>(() => new RiskFactorRepository(repositoryContext));
        _healthInsuranceRepository = new Lazy<IHealthInsuranceRepository>(() => new HealthInsuranceRepository(repositoryContext));
        _medicationCoverageRepository = new Lazy<IMedicationCoverageRepository>(() => new MedicationCoverageRepository(repositoryContext));
        _medicationRepository = new Lazy<IMedicationRepository>(() => new MedicationRepository(repositoryContext));
        _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(repositoryContext));
        _assistantRepository = new Lazy<IAssistantRepository>(() => new AssistantRepository(repositoryContext));
        _doctorRepository = new Lazy<IDoctorRepository>(() => new DoctorRepository(repositoryContext));
        _medicalSpecialtyRepository = new Lazy<IMedicalSpecialtyRepository>(() => new MedicalSpecialtyRepository(repositoryContext));
        _patientRepository = new Lazy<IPatientRepository>(() => new PatientRepository(repositoryContext));

        //_patientDiscapacityRepository = new Lazy<IPatientDiscapacityRepository>(() => new PatientDiscapacityRepository(repositoryContext));
        //_patientIllnessRepository = new Lazy<IPatientIllnessRepository>(() => new PatientIllnessRepository(repositoryContext));
        //_patientRiskFactorRepository = new Lazy<IPatientRiskFactorRepository>(() => new PatientRiskFactorRepository(repositoryContext));
        //_patientHealthInsuranceRepository = new Lazy<IPatientHealthInsuranceRepository>(() => new PatientHealthInsuranceRepository(repositoryContext));
        //_appointmentPrescriptionRepository = new Lazy<IAppointmentPrescriptionRepository>(() => new AppointmentPrescriptionRepository(repositoryContext));
        //_medicationPrescriptionRepository = new Lazy<IMedicationPrescriptionRepository>(() => new MedicationPrescriptionRepository(repositoryContext));
        //_doctorHealthCenterRepository = new Lazy<IDoctorHealthCenterRepository>(() => new DoctorHealthCenterRepository(repositoryContext));
        //_doctorMedicalSpecialtyRepository = new Lazy<IDoctorMedicalSpecialtyRepository>(() => new DoctorMedicalSpecialtyRepository(repositoryContext));
        //_userEntityRelationRepository = new Lazy<IUserEntityRelationRepository>(() => new UserEntityRelationRepository(repositoryContext));
        //_patientAllergyRepository = new Lazy<IPatientAllergyRepository>(() => new PatientAllergyRepository(repositoryContext));
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default) => await _repositoryContext.SaveChangesAsync(cancellationToken);

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _repositoryContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public IICD11Repository ICD11 => _icd11Repository.Value;
    public IAppointmentRepository Appointment => _appointmentRepository.Value;

    public ILabTestRepository LabTest => _labtestRepository.Value;
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
    public IAppointmentPrescriptionRepository AppointmentPrescription => _appointmentPrescriptionRepository.Value;
    public IMedicationRepository Medication => _medicationRepository.Value;
    public IAdminRepository Admin => _adminRepository.Value;
    public IAssistantRepository Assistant => _assistantRepository.Value;
    public IDoctorRepository Doctor => _doctorRepository.Value;
    public IDoctorHealthCenterRepository DoctorHealthCenter => _doctorHealthCenterRepository.Value;
    public IDoctorMedicalSpecialtyRepository DoctorMedicalSpecialty => _doctorMedicalSpecialtyRepository.Value;
    public IMedicalSpecialtyRepository MedicalSpecialty => _medicalSpecialtyRepository.Value;
    public IPatientRepository Patient => _patientRepository.Value;
}
