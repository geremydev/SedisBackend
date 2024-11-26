using AutoMapper;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.DTO.Entities.Locations;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;
using SedisBackend.Core.Domain.DTO.Entities.Prescriptions;
using SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;
using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.DTO.Entities.Users;
using SedisBackend.Core.Domain.DTO.Entities.Users.Admins;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.DTO.Identity.Authentication;
using SedisBackend.Core.Domain.DTO.Identity.Users;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<AuthenticationRequest, LoginDto>()
            .ForMember(dest => dest.Succeeded, opt => opt.Ignore())
            .ForMember(dest => dest.Error, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<RegisterRequest, SaveUserDto>()
            .ForMember(x => x.Succeeded, opt => opt.Ignore())
            .ForMember(x => x.Error, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<ForgotPasswordRequest, ForgotPasswordDto>()
            .ForMember(dest => dest.Succeeded, opt => opt.Ignore())
            .ForMember(dest => dest.Error, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<ResetPasswordRequest, ResetPasswordDto>()
            .ForMember(dest => dest.Succeeded, opt => opt.Ignore())
            .ForMember(dest => dest.Error, opt => opt.Ignore())
            .ReverseMap();

        #region Domain Entities

        #region Appointments
        CreateMap<Appointment, AppointmentDto>()
            .ReverseMap();
        CreateMap<Appointment, AppointmentForUpdateDto>()
            .ReverseMap();
        CreateMap<Appointment, AppointmentForCreationDto>()
            .ReverseMap();
        #endregion

        #region HealthCenters
        CreateMap<HealthCenter, HealthCenterDto>()
            .ReverseMap();
        CreateMap<HealthCenter, HealthCenterForCreationDto>()
            .ReverseMap();
        CreateMap<HealthCenter, HealthCenterForUpdateDto>()
            .ReverseMap();

        //CreateMap<HealthCenterServices, HealthCenterServicesDto>()
        //    .ReverseMap();
        //CreateMap<HealthCenter, SaveHealthCenterServicesDto>()
        //    .ReverseMap();
        //CreateMap<BaseHealthCenterServicesDto, SaveHealthCenterServicesDto>()
        //    .ReverseMap();
        #endregion

        #region Location
        CreateMap<Location, LocationDto>()
                .ReverseMap();
        CreateMap<Location, LocationForCreationDto>()
            .ReverseMap();
        CreateMap<Location, LocationForUpdateDto>()
            .ReverseMap();
        #endregion

        #region Allergies
        CreateMap<Vaccine, VaccineDto>()
            .ReverseMap();
        CreateMap<Vaccine, VaccineForCreationDto>()
            .ReverseMap();
        CreateMap<Vaccine, VaccineForUpdateDto>()
            .ReverseMap();
        #endregion

        #region Medical History

        #region Allergies
        CreateMap<Allergy, AllergyDto>()
            .ReverseMap();
        CreateMap<Allergy, AllergyForCreationDto>()
            .ReverseMap();
        CreateMap<Allergy, AllergyForUpdateDto>()
            .ReverseMap();
        #endregion

        //#region PatientAllergies
        //CreateMap<PatientAllergy, SavePatientAllergyDto>()
        //    .ReverseMap();
        //CreateMap<PatientAllergy, BasePatientAllergyDto>()
        //    .ForMember(p => p.Patient, opt => opt.Ignore())
        //    .ReverseMap();
        //#endregion

        #region Clinical History
        CreateMap<ClinicalHistory, ClinicalHistoryDto>()
            .ReverseMap();
        CreateMap<ClinicalHistory, ClinicalHistoryForUpdateDto>()
                .ReverseMap();
        //CreateMap<ClinicalHistory, ClinicalHistoryDto>()
        //        .ForMember(p => p.Patient, opt => opt.Ignore())
        //        .ReverseMap();
        #endregion

        #region Family History
        CreateMap<FamilyHistory, FamilyHistoryDto>()
                .ReverseMap();
        CreateMap<FamilyHistory, FamilyHistoryForCreationDto>()
                .ReverseMap();
        CreateMap<FamilyHistory, FamilyHistoryForUpdateDto>()
                .ReverseMap();
        #endregion

        #region Medical Conditions

        #region Discapacity Condition

        #region Discapacity
        CreateMap<Discapacity, DiscapacityDto>()
            .ReverseMap();
        CreateMap<Discapacity, DiscapacityForCreationDto>()
                .ReverseMap();
        CreateMap<Discapacity, DiscapacityForUpdateDto>()
                .ReverseMap();
        #endregion

        //#region Patient Discapacity
        //CreateMap<PatientDiscapacity, PatientDiscapacityDto>()
        //        .ReverseMap();
        //CreateMap<PatientDiscapacity, PatientDiscapacityForCreationDto>()
        //        .ReverseMap();
        //CreateMap<PatientDiscapacity, PatientDiscapacityForUpdateDto>()
        //        .ReverseMap();
        //#endregion

        #endregion

        #region Illness Condition

        #region Illness
        CreateMap<Illness, IllnessDto>()
        .ReverseMap();
        CreateMap<Illness, IllnessForCreationDto>()
                .ReverseMap();
        CreateMap<Illness, IllnessForUpdateDto>()
                .ReverseMap();
        #endregion

        //#region Patient Illness
        //CreateMap<PatientIllness, BasePatientIllnessDto>()
        //    .ReverseMap();
        //CreateMap<PatientIllness, SavePatientIllnessDto>()
        //    .ReverseMap();
        //#endregion

        #endregion

        #region RiskFactors

        #region RiskFactor
        CreateMap<RiskFactor, RiskFactorDto>()
            .ForMember(dest => dest.AssessmentLevel, opt => opt.MapFrom(src => src.AssessmentLevel.ToString()))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
            .ForMember(dest => dest.CodeType, opt => opt.MapFrom(src => src.CodeType.ToString()))
            .ReverseMap();
        CreateMap<RiskFactor, RiskFactorForCreationDto>()
            .ReverseMap();
        CreateMap<RiskFactor, RiskFactorForUpdateDto>()
            .ReverseMap();
        #endregion

        //#region Patient RiskFactor
        //CreateMap<PatientRiskFactor, PatientRiskFactorDto>()
        //.ReverseMap();
        //CreateMap<PatientRiskFactor, SavePatientRiskFactorDto>()
        //    .ReverseMap();
        //#endregion

        #endregion

        #endregion

        //#region Vaccines
        //CreateMap<PatientVaccine, PatientVaccineDto>()
        //        .ReverseMap();
        //CreateMap<PatientVaccine, PatientVaccineForCreationDto>()
        //        .ReverseMap();
        //CreateMap<PatientVaccine, PatientVaccineForUpdateDto>()
        //        .ReverseMap();
        //#endregion

        #endregion

        #region Medical Insurance
        //CreateMap<PatientHealthInsurance, BasePatientHealthInsuranceDto>()
        //        .ReverseMap();
        //CreateMap<PatientHealthInsurance, SavePatientHealthInsuranceDto>()
        //        .ReverseMap();

        CreateMap<MedicationCoverage, MedicationCoverageDto>()
            .ReverseMap();
        CreateMap<MedicationCoverage, MedicationCoverageForCreationDto>()
            .ReverseMap();
        CreateMap<MedicationCoverage, MedicationCoverageForUpdateDto>()
            .ReverseMap();

        CreateMap<HealthInsurance, HealthInsuranceDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.InsuranceName, opt => opt.MapFrom(src => src.InsuranceName))
            .ForMember(dest => dest.PolicyType, opt => opt.MapFrom(src => src.PolicyType.ToString()))
            .ForMember(dest => dest.InsuranceCompany, opt => opt.MapFrom(src => src.InsuranceCompany))
            .ForMember(dest => dest.CoverageLevel, opt => opt.MapFrom(src => src.CoverageLevel.ToString()))
            .ForMember(dest => dest.MedicationCoverages, opt => opt.MapFrom(src => src.MedicationCoverages))
            .ForMember(dest => dest.SubscribedPatients, opt => opt.MapFrom(src => src.SubscribedPatients))
            .ReverseMap();
        CreateMap<HealthInsurance, HealthInsuranceForCreationDto>()
            .ReverseMap();
        CreateMap<HealthInsurance, HealthInsuranceForUpdateDto>()
            .ReverseMap();

        CreateMap<PatientHealthInsurance, PatientDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Patient.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Patient.ApplicationUser.LastName))
            .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.Patient.ApplicationUser.CardId))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.Patient.ApplicationUser.IsActive)) //Revisar
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Patient.ApplicationUser.Birthdate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Patient.ApplicationUser.PhoneNumber))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Patient.ApplicationUser.Sex.ToString()))
            .ForMember(dest => dest.PrimaryCarePhysicianId, opt => opt.MapFrom(src => src.Patient.PrimaryCarePhysicianId))
            .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.Patient.BloodType))
            .ForMember(dest => dest.BloodTypeLabResultURl, opt => opt.MapFrom(src => src.Patient.BloodTypeLabResultURl))
            .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Patient.Height))
            .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Patient.Weight))
            .ForMember(dest => dest.EmergencyContactName, opt => opt.MapFrom(src => src.Patient.EmergencyContactName))
            .ForMember(dest => dest.EmergencyContactPhone, opt => opt.MapFrom(src => src.Patient.EmergencyContactPhone))
            .ReverseMap();
        #endregion

        #region Prescriptions

        #region Prescription
        CreateMap<Prescription, PrescriptionDto>()
            .ReverseMap();
        CreateMap<Prescription, PrescriptionForCreationDto>()
            .ReverseMap();
        CreateMap<Prescription, PrescriptionForUpdateDto>()
            .ReverseMap();
        #endregion

        //#region MedicationPrescription
        //CreateMap<MedicationPrescription, BaseMedicationPrescriptionDto>()
        //    .ReverseMap();
        //CreateMap<MedicationPrescription, SaveMedicationPrescriptionDto>()
        //    .ReverseMap();
        //#endregion

        //#region AppointmentPrescription
        //CreateMap<AppointmentPrescription, BaseAppointmentPrescriptionDto>()
        //        .ReverseMap();
        //CreateMap<AppointmentPrescription, SaveAppointmentPrescriptionDto>()
        //    .ReverseMap();
        //#endregion

        #endregion

        #region Products

        #region Medication
        CreateMap<Medication, MedicationDto>()
                .ReverseMap();
        CreateMap<Medication, MedicationForCreationDto>()
            .ReverseMap();
        CreateMap<Medication, MedicationForUpdateDto>()
            .ReverseMap();
        #endregion

        #region LabTests
        CreateMap<LabTest, LabTestDto>()
            .ReverseMap();
        CreateMap<LabTest, LabTestForCreationDto>()
            .ReverseMap();
        CreateMap<LabTest, LabTestForUpdateDto>()
            .ReverseMap();
        #endregion

        #endregion

        #region Users

        CreateMap<User, BaseUserForUpdateDto>()
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex.ToString()))
            .ReverseMap()
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src =>
                src.Sex == "m" ? SexEnum.M :
                src.Sex == "f" ? SexEnum.F :
                SexEnum.M));


        #region Patients
        CreateMap<Patient, PatientDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
            .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.ApplicationUser.CardId))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.ApplicationUser.Birthdate))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.ApplicationUser.Sex.ToString()))
            .ForMember(dest => dest.PrimaryCarePhysicianId, opt => opt.MapFrom(src => src.PrimaryCarePhysicianId))
            .ForMember(dest => dest.Allergies, opt => opt.MapFrom(src => src.Allergies.Select(a => a.Allergy)))
            .ForMember(dest => dest.Illnesses, opt => opt.MapFrom(src => src.Illnesses.Select(a=>a.Illness)))
            .ForMember(dest => dest.Discapacities, opt => opt.MapFrom(src => src.Discapacities.Select(d => d.Discapacity)))
            .ForMember(dest => dest.RiskFactors, opt => opt.MapFrom(src => src.RiskFactors.Select(r => r.RiskFactor)))
            .ForMember(dest => dest.Vaccines, opt => opt.MapFrom(src => src.Vaccines.Select(v => v.Vaccine)))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());
        CreateMap<Patient, PatientForCreationDto>()
            .ReverseMap();
        CreateMap<Patient, PatientForUpdateDto>()
            .ReverseMap();
        #endregion

        #region Doctors

        #region Doctor
        CreateMap<DoctorForCreationDto, Doctor>()
            .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber));

        CreateMap<DoctorForUpdateDto, Doctor>()
            .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber));

        CreateMap<Doctor, DoctorDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
            .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.ApplicationUser.CardId))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.ApplicationUser.Birthdate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ApplicationUser.PhoneNumber))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.ApplicationUser.Sex.ToString()))
            .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
            .ForMember(dest => dest.CurrentlyWorkingHealthCenters, opt => opt.MapFrom(src => src.CurrentlyWorkingHealthCenters))
            .ForMember(dest => dest.Specialties, opt => opt.MapFrom(src => src.Specialties))
            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments))
            .ForMember(dest => dest.DevelopedClinicalHistories, opt => opt.MapFrom(src => src.DevelopedClinicalHistories))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());

        CreateMap<Doctor, DoctorForCreationDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUser))
            .ForMember(dest => dest.LicenseNumber, opt => opt.MapFrom(src => src.LicenseNumber))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());

        CreateMap<Doctor, DoctorForUpdateDto>()
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());
        #endregion

        #region DoctorHeatlhCenter
        CreateMap<DoctorHealthCenter, HealthCenterDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.HealthCenter.Name))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.HealthCenter.LocationId))
            .ForMember(dest => dest.HealthCenterCategory, opt => opt.MapFrom(src => src.HealthCenter.HealthCenterCategory))
            .ReverseMap();
        CreateMap<DoctorHealthCenter, HealthCenterForCreationDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.HealthCenter.Name))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.HealthCenter.LocationId))
            .ForMember(dest => dest.HealthCenterCategory, opt => opt.MapFrom(src => src.HealthCenter.HealthCenterCategory))
            .ReverseMap();
        CreateMap<DoctorHealthCenter, HealthCenterForUpdateDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.HealthCenter.Name))
            .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.HealthCenter.LocationId))
            .ForMember(dest => dest.HealthCenterCategory, opt => opt.MapFrom(src => src.HealthCenter.HealthCenterCategory))
            .ReverseMap();
        #endregion

        #region DoctorMedicalSpecialty
        CreateMap<DoctorMedicalSpecialty, MedicalSpecialtyDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MedicalSpecialty.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.MedicalSpecialty.Description))
            .ReverseMap();
        #endregion

        #region MedicalSpecialty
        CreateMap<MedicalSpecialty, MedicalSpecialtyDto>()
            .ReverseMap();
        CreateMap<MedicalSpecialty, MedicalSpecialtyForCreationDto>()
            .ReverseMap();
        CreateMap<MedicalSpecialty, MedicalSpecialtyForUpdateDto>()
            .ReverseMap();
        #endregion

        #endregion

        #region Admin  
        CreateMap<Admin, AdminDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
            .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.ApplicationUser.CardId))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.ApplicationUser.Birthdate))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.ApplicationUser.Sex.ToString()))
            .ForMember(dest => dest.HealthCenter, opt => opt.MapFrom(src => src.HealthCenter))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore()); // Ignore ApplicationUser for reverse mapping

        CreateMap<Admin, AdminForCreationDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUser))
            .ForMember(dest => dest.HealthCenterId, opt => opt.MapFrom(src => src.HealthCenterId))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore()); // Ignore ApplicationUser for reverse mapping

        CreateMap<Admin, AdminForUpdateDto>()
            .ForMember(dest => dest.HealthCenterId, opt => opt.MapFrom(src => src.HealthCenterId))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore()) // Ignore ApplicationUser for reverse mapping
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        

        CreateMap<AdminDto, AdminForUpdateDto>()
           .ReverseMap();
        #endregion

        #region Assistant 
        CreateMap<Assistant, AssistantDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
            .ForMember(dest => dest.CardId, opt => opt.MapFrom(src => src.ApplicationUser.CardId))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.ApplicationUser.Birthdate))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ApplicationUser.PhoneNumber))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.ApplicationUser.Sex.ToString()))
            .ForMember(dest => dest.HealthCenter, opt => opt.MapFrom(src => src.HealthCenter))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());
        CreateMap<Assistant, AssistantForCreationDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUser))
            .ForMember(dest => dest.HealthCenterId, opt => opt.MapFrom(src => src.HealthCenterId))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());

        CreateMap<Assistant, AssistantForUpdateDto>()
            .ForMember(dest => dest.HealthCenterId, opt => opt.MapFrom(src => src.HealthCenterId))
            .ReverseMap()
            .ForMember(dest => dest.ApplicationUser, opt => opt.Ignore());

        CreateMap<AssistantDto, AssistantForUpdateDto>()
           .ReverseMap();
        #endregion

        #endregion

        #endregion

        CreateMap<RegisterRequest, PatientForUpdateDto>()
            //.ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();

        //CreateMap<PatientDto, AdminForUpdateDto>()
        //    .ReverseMap();
        //CreateMap<PatientDto, AssistantForUpdateDto>()
        //    .ReverseMap();

        CreateMap<User, BaseUserDto>()
                .ReverseMap();
        CreateMap<User, BaseUserForCreationDto>()
                .ReverseMap();
        CreateMap<User, BaseUserForUpdateDto>()
                .ReverseMap();
    }
}
