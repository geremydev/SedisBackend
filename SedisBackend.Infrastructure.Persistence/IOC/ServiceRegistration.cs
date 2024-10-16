using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Http;

namespace SedisBackend.Infrastructure.Persistence.IOC
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<SedisContext>(options =>
                                                              options.UseInMemoryDatabase("Sedis"));
            }
            else
            {
                services.AddDbContext<SedisContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly(typeof(SedisContext).Assembly.FullName)));
            }
            #endregion
            services.AddHttpClient();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            /*
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #region Appointments   
            services.AddTransient<IAppointmentRepository, AppointmentRepository>(); 
            #endregion

            #region HealthCenters
            services.AddTransient<IHealthCenterRepository, HealthCenterRepository>();
            services.AddTransient<IHealthCenterServicesRepository, HealthCenterServicesRepository>();

            #endregion

            #region Location
            services.AddTransient<ILocationRepository, LocationRepository>();
            #endregion

            #region Location
            services.AddTransient<IUserEntityRelationRepository, UserEntityRelationRepository>();
            #endregion

            #region Medical History
            #region Allergies
            services.AddTransient<IAllergyRepository, AllergyRepository>();
            services.AddTransient<IPatientAllergyRepository, PatientAllergyRepository>();

            #endregion

            #region Clinical History
            services.AddTransient<IClinicalHistoryRepository, ClinicalHistoryRepository>();
            #endregion

            #region Family History
            services.AddTransient<IFamilyHistoryRepository, FamilyHistoryRepository>();

            #endregion

            #region Medical Conditions

            #region Discapacity Condition
            services.AddTransient<IDiscapacityRepository, DiscapacityRepository>();
            services.AddTransient<IPatientDiscapacityRepository, PatientDiscapacityRepository>();
            #endregion

            #region Illness Condition
            services.AddTransient<IIllnessRepository, IllnessRepository>();
            services.AddTransient<IPatientIllnessRepository, PatientIllnessRepository>();

            #endregion

            #region RiskFactor
            services.AddTransient<IRiskFactorRepository, RiskFactorRepository>();
            services.AddTransient<IPatientRiskFactorRepository, PatientRiskFactorRepository>();

            #endregion

            #endregion

            #region Vaccines
            services.AddTransient<IVaccineRepository, VaccineRepository>();
            services.AddTransient<IPatientVaccineRepository, PatientVaccineRepository>();

            #endregion

            #endregion

            #region UserEntityRelation
            services.AddTransient<IUserEntityRelationRepository, UserEntityRelationRepository>();
            #endregion

            #region Medical Insurance
            services.AddTransient<IHealthInsuranceRepository, HealthInsuranceRepository>();
            services.AddTransient<IMedicationCoverageRepository, MedicationCoverageRepository>();
            services.AddTransient<IPatientHealthInsuranceRepository, PatientHealthInsuranceRepository>();
            #endregion

            #region Presctiption
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            services.AddTransient<IMedicationPrescriptionRepository, MedicationPrescriptionRepository>();
            services.AddTransient<ILabTestPrescriptionRepository, LabTestPrescriptionRepository>();
            #endregion

            #region Products
            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddTransient<ILabTestRepository, LabTestRepository>();
            #endregion

            #region Users
            #region Patient
            services.AddTransient<IPatientRepository, PatientRepository>();

            #endregion

            #region Doctor
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IDoctorHealthCenterRepository, DoctorHealthCenterRepository>();
            services.AddTransient<IDoctorMedicalSpecialtyRepository, DoctorMedicalSpecialtyRepository>();
            services.AddTransient<IMedicalSpecialtyRepository, MedicalSpecialtyRepository>();

            #endregion

            #region Admin
            services.AddTransient<IAdminRepository, AdminRepository>();

            #endregion

            #region Assistant
            services.AddTransient<IAssistantRepository, AssistantRepository>();
            #endregion

            #endregion


            #endregion
            */
        }
    }
}
