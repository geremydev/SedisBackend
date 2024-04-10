#region usings

using Microsoft.Extensions.DependencyInjection;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Application.Interfaces.Services;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Application.Services;
using System.Reflection;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Appointments;
using SedisBackend.Core.Application.Services.Domain_Services.Appointments;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Health_Centers;
using SedisBackend.Core.Application.Services.Domain_Services.Health_Centers;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Locations;
using SedisBackend.Core.Application.Services.Domain_Services.Locations;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Allergies;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Allergies;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Family_History;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Family_History;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_History.Vaccines;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_History.Vaccines;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Services.Domain_Services.Medical_Insurance;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Presctiprions;
using SedisBackend.Core.Application.Services.Domain_Services.Prescriptions;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Services.Domain_Services.Products;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Application.Services.Domain_Services.User_Entity_Relation;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Admins;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Admins;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Assistants;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Assistants;

#endregion

namespace SedisBackend.Core.Application.IOC
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
        }
    }
}
