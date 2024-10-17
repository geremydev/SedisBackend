#region usings

using Microsoft.Extensions.DependencyInjection;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Application.Services;
using System.Reflection;

#endregion

namespace SedisBackend.Core.Application.IOC
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IServiceManager, ServiceManager>();
            /*
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();

            #region Domain Services

            #region Appointments    
            services.AddTransient<IAppointmentService, AppointmentService>();

            #endregion

            #region HealthCenters
            services.AddTransient<IHealthCenterService, HealthCenterService>();
            services.AddTransient<IHealthCenterServicesService, HealthCenterServicesService>();

            #endregion

            #region Location
            services.AddTransient<ILocationService, LocationService>();

            #endregion

            #region Medical History

            #region Allergies
            services.AddTransient<IAllergyService, AllergyService>();
            services.AddTransient<IPatientAllergyService, PatientAllergyService>();

            #endregion

            #region Clinical History
            services.AddTransient<IClinicalHistoryService, ClinicalHistoryService>();

            #endregion

            #region Family History
            services.AddTransient<IFamilyHistoryService, FamilyHistoryService>();

            #endregion

            #region Medical Conditions

            #region Discapacity Condition
            services.AddTransient<IDiscapacityService, DiscapacityService>();
            services.AddTransient<IPatientDiscapacityService, PatientDiscapacityService>();

            #endregion

            #region Illness Condition
            services.AddTransient<IIllnessService, IllnessService>();
            services.AddTransient<IPatientIllnessService, PatientIllnessService>();

            #endregion

            #region RiskFactor
            services.AddTransient<IRiskFactorService, RiskFactorService>();
            services.AddTransient<IPatientRiskFactorService, PatientRiskFactorService>();

            #endregion

            #endregion

            #region Vaccines
            services.AddTransient<IVaccineService, VaccineService>();
            services.AddTransient<IPatientVaccineService, PatientVaccineService>();

            #endregion

            #endregion

            #region Medical Insurance
            services.AddTransient<IHealthInsuranceService, HealthInsuranceService>();
            services.AddTransient<IMedicationCoverageService, MedicationCoverageService>();
            services.AddTransient<IPatientHealthInsuranceService, PatientHealthInsuranceService>();

            #endregion

            #region UserEntityRelation
            services.AddTransient<IUserEntityRelationService, UserEntityRelationService>();
            #endregion

            #region Prescription
            services.AddTransient<IPrescriptionService, PrescriptionService>();
            services.AddTransient<IMedicationService, MedicationService>();
            services.AddTransient<IMedicationPrescriptionService, MedicationPrescriptionService>();
            services.AddTransient<ILabTestPrescriptionService, LabTestPrescriptionService>();

            #endregion

            #region Products
            services.AddTransient<ILabTestService, LabTestService>();
            services.AddTransient<IMedicationService, MedicationService>();

            #endregion

            #region Users

            #region Patient
            services.AddTransient<IPatientService, PatientService>();

            #endregion

            #region Doctor
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IDoctorHealthCenterService, DoctorHealthCenterService>();
            services.AddTransient<IDoctorMedicalSpecialtyService, DoctorMedicalSpecialtyService>();
            services.AddTransient<IMedicalSpecialtyService, MedicalSpecialtyService>();

            #endregion

            #region Admin
            services.AddTransient<IAdminService, AdminService>();
            #endregion

            #region Assistant
            services.AddTransient<IAssistantService, AssistantService>();
            #endregion

            #endregion


            #endregion

            #endregion
            */
        }
    }
}
