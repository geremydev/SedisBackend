﻿#region usings

using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Health_Centers;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Locations;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Prescriptions;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Products;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Account;
using SedisBackend.Core.Application.Dtos.Identity_Dtos.Users;
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
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Patients;
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
using SedisBackend.Core.Application.Services.Domain_Services.Users.Doctors;
using SedisBackend.Core.Application.Services.Domain_Services.Users.Patients;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Locations;
using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Medical_Insurance;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Products;
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
                .ForMember(p=>p.Patient, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region Clinical History
            CreateMap<ClinicalHistory, SaveClinicalHistoryDto>()
                    .ReverseMap();
            CreateMap<ClinicalHistory, BaseClinicalHistoryDto>()
                    .ForMember(p => p.Patient, opt => opt.Ignore())
                    .ReverseMap();
            CreateMap<ClinicalHistory, BaseClinicalHistoryDto>()
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
            CreateMap<Discapacity, BaseDiscapacityDto>()
                .ReverseMap();


            CreateMap<Discapacity, SaveDiscapacityDto>()
                .ReverseMap();


            CreateMap<PatientDiscapacity, BasePatientDiscapacityDto>()
                .ReverseMap();


            CreateMap<PatientDiscapacity, SavePatientDiscapacityDto>()
                .ReverseMap();
            #endregion

            #region Illness Condition
            CreateMap<Illness, BaseIllnessDto>()
                .ReverseMap();


            CreateMap<Illness, SaveIllnessDto>()
                .ReverseMap();


            CreateMap<PatientIllness, BasePatientIllnessDto>()
                .ReverseMap();


            CreateMap<PatientIllness, SavePatientIllnessDto>()
                .ReverseMap();
            #endregion

            #region RiskFactor
            CreateMap<RiskFactor, BaseRiskFactorDto>()
                .ReverseMap();


            CreateMap<RiskFactor, SaveRiskFactorDto>()
                .ReverseMap();


            CreateMap<PatientRiskFactor, BasePatientRiskFactorDto>()
                .ReverseMap();


            CreateMap<PatientRiskFactor, SavePatientRiskFactorDto>()
                .ReverseMap();
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
            #endregion

            #region Medical Insurance
            CreateMap<PatientHealthInsurance, BasePatientHealthInsuranceDto>()
                .ReverseMap();


            CreateMap<PatientHealthInsurance, SavePatientHealthInsuranceDto>()
                .ReverseMap();

            CreateMap<MedicationCoverage, BaseMedicationCoverageDto>()
                .ReverseMap();


            CreateMap<MedicationCoverage, SaveMedicationlCoverageDto>()
                .ReverseMap();


            CreateMap<HealthInsurance, BaseHealthInsuranceDto>()
                .ReverseMap();


            #region LabTestPrescription
            CreateMap<LabTestPrescription, BaseLabTestPrescriptionDto>()
                    .ReverseMap();
                CreateMap<LabTestPrescription, SaveLabTestPrescriptionDto>()
                    .ReverseMap();
            #endregion

            #region Presctiption
            CreateMap<Prescription, BasePrescriptionDto>()
                .ReverseMap();


            CreateMap<Prescription, SavePrescriptionDto>()
                .ReverseMap();


            CreateMap<MedicationPrescription, BaseMedicationPrescriptionDto>()
                .ReverseMap();


            CreateMap<MedicationPrescription, SaveMedicationPrescriptionDto>()
                .ReverseMap();
            #endregion

            #region Products

            #region Medication
                CreateMap<Medication, BaseMedicationDto>()
                    .ReverseMap();
                CreateMap<Medication, SaveMedicationDto>()
                    .ReverseMap();
            #endregion

            #endregion

            #region Users

            #region Patient
            CreateMap<BasePatientDto, SavePatientDto>()
                .ReverseMap();
            CreateMap<Patient, SavePatientDto>()
                .ReverseMap();


            

            #endregion

            #region Doctor
            CreateMap<Doctor, BaseDoctorDto>()
                .ReverseMap();
            CreateMap<Doctor, SaveDoctorDto>()
                .ReverseMap();
            #endregion

            #endregion


            #endregion
        }
    }
}
