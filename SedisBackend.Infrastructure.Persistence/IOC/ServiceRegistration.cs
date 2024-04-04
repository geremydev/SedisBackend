using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SedisBackend.Core.Application.Interfaces.Repositories;
using SedisBackend.Core.Application.Interfaces.Repositories.Appointments;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Repositories.Medical_History;
using SedisBackend.Core.Application.Interfaces.Repositories.Prescriptions;
using SedisBackend.Core.Application.Interfaces.Repositories.Products;
using SedisBackend.Infrastructure.Persistence.Contexts;
using SedisBackend.Infrastructure.Persistence.Repositories;
using SedisBackend.Infrastructure.Persistence.Repositories.Appointments;
using SedisBackend.Infrastructure.Persistence.Repositories.Base;
using SedisBackend.Infrastructure.Persistence.Repositories.Medical_History;
using SedisBackend.Infrastructure.Persistence.Repositories.Presctiption;
using SedisBackend.Infrastructure.Persistence.Repositories.Products;

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

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IHealthCenterRepository, HealthCenterRepository>();

            services.AddTransient<IAllergyRepository, AllergyRepository>();
            services.AddTransient<IPatientAllergyRepository, PatientAllergyRepository>();

            services.AddTransient<IClinicalHistoryRepository, ClinicalHistoryRepository>();
            services.AddTransient<IFamilyHistoryRepository, FamilyHistoryRepository>();
            services.AddTransient<IPatientVaccineRepository, PatientVaccineRepository>();
            services.AddTransient<IVaccineRepository, VaccineRepository>();

            services.AddTransient<IHealthInsuranceRepository, HealthInsuranceRepository>();
            services.AddTransient<IMedicationCoverageRepository, MedicationCoverageRespository>();

            services.AddTransient<IMedicationPrescriptionRepository, MedicationPrescriptionRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();

            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddTransient<ILabTestRepository, LabTestRepository>();
            #endregion
        }
    }
}
