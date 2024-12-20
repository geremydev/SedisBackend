﻿using Microsoft.EntityFrameworkCore.Storage;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Interfaces.Repositories.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories.Users;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories.ModelsRepositories;
using SedisBackend.Infrastructure.Persistence.Repositories.RelationsRepositories;
using SedisBackend.Infrastructure.Persistence.Repositories.UserRepositories;

namespace SedisBackend.Infrastructure.Persistence.Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly SedisContext _repositoryContext;

    private readonly Lazy<IAppointmentRepository> _appointmentRepository;
    private readonly Lazy<ILabTestRepository> _labtestRepository;
    private readonly Lazy<IHealthCenterRepository> _healthCenterRepository;
    private readonly Lazy<IHealthCenterServicesRepository> _healthCenterServicesRepository;
    private readonly Lazy<ILocationRepository> _locationRepository;
    private readonly Lazy<IUserEntityRelationRepository> _userEntityRelationRepository;
    private readonly Lazy<IAllergyRepository> _allergyRepository;
    private readonly Lazy<IPatientAllergyRepository> _patientAllergyRepository;
    private readonly Lazy<IMedicalConsultationRepository> _medicalConsultationRepository;
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
    private readonly Lazy<IPatientHealthInsuranceRepository> _patientHealthInsuranceRepository;
    private readonly Lazy<IMedicationRepository> _medicationRepository;
    private readonly Lazy<IAdminRepository> _adminRepository;
    private readonly Lazy<IAssistantRepository> _assistantRepository;
    private readonly Lazy<IDoctorRepository> _doctorRepository;
    private readonly Lazy<IDoctorMedicalSpecialtyRepository> _doctorMedicalSpecialtyRepository;
    private readonly Lazy<IMedicalSpecialtyRepository> _medicalSpecialtyRepository;
    private readonly Lazy<IPatientRepository> _patientRepository;
    private readonly Lazy<ILabTechRepository> _labTechRepository;
    private readonly Lazy<IRegistratorRepository> _registratorRepository;
    private readonly Lazy<IPatientMedicationPrescriptionRepository> _patientMedicationPrescriptionRepository;
    private readonly Lazy<IPatientLabTestPrescriptionRepository> _patientLabTestPrescriptionRepository;
    private readonly Lazy<IPatientVaccineRepository> _patientVaccineRepository;

    public RepositoryManager(SedisContext repositoryContext, HttpClient httpClient)
    {
        _repositoryContext = repositoryContext;

        //_icd11Repository = new Lazy<IICD11Repository>(() => new ICD11Repository(httpClient));

        _labtestRepository = new Lazy<ILabTestRepository>(() => new LabTestRepository(repositoryContext));
        _appointmentRepository = new Lazy<IAppointmentRepository>(() => new AppointmentRepository(repositoryContext));
        _healthCenterRepository = new Lazy<IHealthCenterRepository>(() => new HealthCenterRepository(repositoryContext));
        _healthCenterServicesRepository = new Lazy<IHealthCenterServicesRepository>(() => new HealthCenterServicesRepository(repositoryContext));
        _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
        _allergyRepository = new Lazy<IAllergyRepository>(() => new AllergyRepository(repositoryContext));
        _medicalConsultationRepository = new Lazy<IMedicalConsultationRepository>(() => new MedicalConsultationRepository(repositoryContext));
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
        _labTechRepository = new Lazy<ILabTechRepository>(() => new LabTechRepository(repositoryContext));
        _registratorRepository = new Lazy<IRegistratorRepository>(() => new RegistratorRepository(repositoryContext));
        _patientAllergyRepository = new Lazy<IPatientAllergyRepository>(() => new PatientAllergyRepository(repositoryContext));

        _patientVaccineRepository = new Lazy<IPatientVaccineRepository>(() => new PatientVaccineRepository(repositoryContext));
        _patientDiscapacityRepository = new Lazy<IPatientDiscapacityRepository>(() => new PatientDiscapacityRepository(repositoryContext));
        _patientIllnessRepository = new Lazy<IPatientIllnessRepository>(() => new PatientIllnessRepository(repositoryContext));
        _patientRiskFactorRepository = new Lazy<IPatientRiskFactorRepository>(() => new PatientRiskFactorRepository(repositoryContext));
        _patientHealthInsuranceRepository = new Lazy<IPatientHealthInsuranceRepository>(() => new PatientHealthInsuranceRepository(repositoryContext));
        _doctorMedicalSpecialtyRepository = new Lazy<IDoctorMedicalSpecialtyRepository>(() => new DoctorMedicalSpecialtyRepository(repositoryContext));
        _patientMedicationPrescriptionRepository = new Lazy<IPatientMedicationPrescriptionRepository>(() => new PatientMedicationPrescriptionRepository(repositoryContext));
        _patientLabTestPrescriptionRepository = new Lazy<IPatientLabTestPrescriptionRepository>(() => new PatientLabTestPrescriptionRepository(repositoryContext));
        //_userEntityRelationRepository = new Lazy<IUserEntityRelationRepository>(() => new UserEntityRelationRepository(repositoryContext));
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default) => await _repositoryContext.SaveChangesAsync(cancellationToken);

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await _repositoryContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task<IExecutionStrategy> CreateExecutionStrategy(CancellationToken cancellationToken = default)
    {
        return _repositoryContext.Database.CreateExecutionStrategy();
    }

    public IAppointmentRepository Appointment => _appointmentRepository.Value;

    public ILabTestRepository LabTest => _labtestRepository.Value;
    public IHealthCenterRepository HealthCenter => _healthCenterRepository.Value;
    public IHealthCenterServicesRepository HealthCenterServices => _healthCenterServicesRepository.Value;
    public ILocationRepository Location => _locationRepository.Value;
    public IUserEntityRelationRepository UserEntityRelation => _userEntityRelationRepository.Value;
    public IAllergyRepository Allergy => _allergyRepository.Value;
    public IPatientAllergyRepository PatientAllergy => _patientAllergyRepository.Value;
    public IMedicalConsultationRepository MedicalConsultation => _medicalConsultationRepository.Value;
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
    public IPatientHealthInsuranceRepository PatientHealthInsurance => _patientHealthInsuranceRepository.Value;
    public IMedicationRepository Medication => _medicationRepository.Value;
    public IAdminRepository Admin => _adminRepository.Value;
    public IAssistantRepository Assistant => _assistantRepository.Value;
    public IDoctorRepository Doctor => _doctorRepository.Value;
    public IDoctorMedicalSpecialtyRepository DoctorMedicalSpecialty => _doctorMedicalSpecialtyRepository.Value;
    public IMedicalSpecialtyRepository MedicalSpecialty => _medicalSpecialtyRepository.Value;
    public IPatientRepository Patient => _patientRepository.Value;
    public IRegistratorRepository Registrator => _registratorRepository.Value;
    public ILabTechRepository LabTech => _labTechRepository.Value;
    public IPatientMedicationPrescriptionRepository PatientMedicationPrescription => _patientMedicationPrescriptionRepository.Value;
    public IPatientLabTestPrescriptionRepository PatientLabTestPrescription => _patientLabTestPrescriptionRepository.Value;
    public IPatientVaccineRepository PatientVaccineRepository => _patientVaccineRepository.Value;
}
