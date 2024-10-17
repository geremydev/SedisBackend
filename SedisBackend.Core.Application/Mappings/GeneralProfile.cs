#region usings

using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Products;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Users;
using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Locations;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Products;
using SedisBackend.Core.Domain.UserEntityRelation;
using SedisBackend.Core.Domain.Users.Admins;
using SedisBackend.Core.Domain.Users.Assistants;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;

#endregion

namespace SedisBackend.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<AuthenticationRequest, LoginDto>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserDto>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordDto>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordDto>()
                .ForMember(dest => dest.HasError, opt => opt.Ignore())
                .ForMember(dest => dest.Error, opt => opt.Ignore())
                .ReverseMap();

            #region Domain Services

            #region Appointments
            CreateMap<Appointment, SaveAppointmentDto>()
                .ReverseMap();
            CreateMap<Appointment, BaseAppointmentDto>()
                .ReverseMap();
            #endregion

            #region HealthCenters
            CreateMap<HealthCenter, BaseHealthCenterDto>()
                .ReverseMap();
            CreateMap<HealthCenter, SaveHealthCenterDto>()
                .ReverseMap();

            CreateMap<HealthCenterServices, BaseHealthCenterServicesDto>()
                .ReverseMap();
            CreateMap<HealthCenter, SaveHealthCenterServicesDto>()
                .ReverseMap();
            CreateMap<BaseHealthCenterServicesDto, SaveHealthCenterServicesDto>()
                .ReverseMap();


            #endregion

            #region Location
            CreateMap<Location, BaseLocationDto>()
                    .ReverseMap();
            CreateMap<Location, SaveLocationDto>()
                .ReverseMap();
            #endregion

            #region Medical History

            #region Allergies
            CreateMap<Allergy, SaveAllergyDto>()
                .ReverseMap();
            CreateMap<Allergy, BaseAllergyDto>()
                .ReverseMap();
            #endregion

            #region PatientAllergies
            CreateMap<PatientAllergy, SavePatientAllergyDto>()
                .ReverseMap();
            CreateMap<PatientAllergy, BasePatientAllergyDto>()
                .ForMember(p => p.Patient, opt => opt.Ignore())
                .ReverseMap();
            #endregion

            #region Clinical History
            CreateMap<ClinicalHistory, SaveClinicalHistoryDto>()
                    .ReverseMap();
            CreateMap<ClinicalHistory, BaseClinicalHistoryDto>()
                    .ForMember(p => p.Patient, opt => opt.Ignore())
                    .ReverseMap();
            #endregion

            #region Family History
            CreateMap<FamilyHistory, BaseFamilyHistoryDto>()
                    .ReverseMap();
            CreateMap<FamilyHistory, SaveFamilyHistoryDto>()
                    .ReverseMap();
            #endregion

            #region Medical Conditions

            #region Discapacity Condition

            #region Discapacity
            CreateMap<Discapacity, BaseDiscapacityDto>()
                .ReverseMap();
            CreateMap<Discapacity, SaveDiscapacityDto>()
                .ReverseMap();
            #endregion

            #region Patient Discapacity
            CreateMap<PatientDiscapacity, BasePatientDiscapacityDto>()
                    .ReverseMap();
            CreateMap<PatientDiscapacity, SavePatientDiscapacityDto>()
                .ReverseMap();
            #endregion

            #endregion

            #region Illness Condition

            #region Illness
            CreateMap<Illness, BaseIllnessDto>()
            .ReverseMap();
            CreateMap<Illness, SaveIllnessDto>()
                .ReverseMap();
            #endregion

            #region Patient Illness
            CreateMap<PatientIllness, BasePatientIllnessDto>()
                .ReverseMap();
            CreateMap<PatientIllness, SavePatientIllnessDto>()
                .ReverseMap();
            #endregion

            #endregion

            #region RiskFactors

            #region RiskFactor
            CreateMap<RiskFactor, BaseRiskFactorDto>()
                .ReverseMap();
            CreateMap<RiskFactor, SaveRiskFactorDto>()
                .ReverseMap();
            #endregion

            #region Patient RiskFactor
            CreateMap<PatientRiskFactor, BasePatientRiskFactorDto>()
            .ReverseMap();
            CreateMap<PatientRiskFactor, SavePatientRiskFactorDto>()
                .ReverseMap();
            #endregion

            #endregion

            #endregion

            #region Vaccines
            CreateMap<PatientVaccine, BasePatientVaccineDto>()
                    .ReverseMap();
            CreateMap<PatientVaccine, SavePatientVaccineDto>()
                    .ReverseMap();
            #endregion

            #endregion

            #region Medical Insurance
            CreateMap<PatientHealthInsurance, BasePatientHealthInsuranceDto>()
                    .ReverseMap();
            CreateMap<PatientHealthInsurance, SavePatientHealthInsuranceDto>()
                    .ReverseMap();
            CreateMap<MedicationCoverage, SaveMedicationlCoverageDto>()
                .ReverseMap();
            CreateMap<MedicationCoverage, BaseMedicationCoverageDto>()
                .ReverseMap();
            CreateMap<HealthInsurance, BaseHealthInsuranceDto>()
                .ReverseMap();
            CreateMap<HealthInsurance, SaveHealthInsuranceDto>()
                .ReverseMap();
            #endregion

            #region Prescriptions

            #region Prescription
            CreateMap<Prescription, BasePrescriptionDto>()
                .ReverseMap();
            CreateMap<Prescription, SavePrescriptionDto>()
                .ReverseMap();
            #endregion

            #region MedicationPrescription
            CreateMap<MedicationPrescription, BaseMedicationPrescriptionDto>()
                .ReverseMap();
            CreateMap<MedicationPrescription, SaveMedicationPrescriptionDto>()
                .ReverseMap();
            #endregion

            #region LabTestPrescription
            CreateMap<LabTestPrescription, BaseLabTestPrescriptionDto>()
                    .ReverseMap();
            CreateMap<LabTestPrescription, SaveLabTestPrescriptionDto>()
                .ReverseMap();
            #endregion

            #endregion

            #region Products

            #region Medication
            CreateMap<Medication, BaseMedicationDto>()
                    .ReverseMap();
            CreateMap<Medication, SaveMedicationDto>()
                .ReverseMap();
            #endregion

            #region LabTest
            CreateMap<LabTest, BaseLabTestDto>()
                .ReverseMap();
            CreateMap<LabTest, SaveLabTestDto>()
                .ReverseMap();
            #endregion

            #endregion

            #region Users

            #region Patients
            CreateMap<BasePatientDto, SavePatientDto>()
                .ReverseMap();
            CreateMap<Patient, SavePatientDto>()
                .ReverseMap();
            CreateMap<Patient, BasePatientDto>()
                    .ReverseMap();
            #endregion

            #region Doctors

            #region Doctor
            CreateMap<Doctor, BaseDoctorDto>()
                    .ReverseMap();
            CreateMap<Doctor, SaveDoctorDto>()
                .ReverseMap();
            #endregion

            #region DoctorHeatlhCenter
            CreateMap<DoctorHealthCenter, BaseDoctorHealthCenterDto>()
                .ReverseMap();
            CreateMap<DoctorHealthCenter, SaveDoctorHealthCenterDto>()
                .ReverseMap();
            #endregion

            #region DoctorMedicalSpecialty
            CreateMap<DoctorMedicalSpecialty, BaseMedicalSpeciality>()
                .ReverseMap();
            CreateMap<DoctorMedicalSpecialty, SaveDoctorMedicalSpecialtyDto>()
                .ReverseMap();
            #endregion

            #region MedicalSpecialty
            CreateMap<MedicalSpecialty, BaseMedicalSpecialtyDto>()
                .ReverseMap();
            CreateMap<MedicalSpecialty, SaveMedicalSpecialityDto>()
                .ReverseMap();
            #endregion

            #endregion

            #region Admin  
            CreateMap<BaseAdminDto, SaveAdminDto>()
               .ReverseMap();
            CreateMap<Admin, SaveAdminDto>()
                .ReverseMap();
            CreateMap<Admin, BaseAdminDto>()
                    .ReverseMap();
            #endregion

            #region Assistant 
            CreateMap<BaseAssistantDto, SaveAssistantDto>()
               .ReverseMap();
            CreateMap<Assistant, SaveAssistantDto>()
                .ReverseMap();
            CreateMap<Assistant, BaseAssistantDto>()
                    .ReverseMap();
            #endregion

            #endregion

            #endregion

            CreateMap<RegisterRequest, SavePatientDto>()
                //.ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UserEntityRelation, SaveUserEntityRelationDto>()
                .ReverseMap();

            CreateMap<UserEntityRelation, BaseUserEntityRelationDto>()
                .ReverseMap();
            CreateMap<BaseUserEntityRelationDto, SaveUserEntityRelationDto>()
                .ReverseMap();

            CreateMap<BasePatientDto, SaveAdminDto>()
                .ReverseMap();
            CreateMap<BasePatientDto, SaveAssistantDto>()
                .ReverseMap();

        }
    }
}
