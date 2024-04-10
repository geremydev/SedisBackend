using SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients
{
    public class BasePatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public string BloodType { get; set; }
        public string? BloodTypeLabResultURl { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public int? PrimaryCarePhysicianId { get; set; }
        public List<BaseClinicalHistoryDto> ClinicalHistories { get; set; }
        public List<BaseAppointmentDto>? Appointments { get; set; }
        public List<BasePatientAllergyDto>? Allergies { get; set; }
        public List<BaseIllnessDto>? Illnesses { get; set; }
        public List<BasePatientDiscapacityDto>? Discapacities { get; set; }
        public List<BasePatientRiskFactorDto>? RiskFactors { get; set; }
        public List<BasePatientVaccineDto>? Vaccines { get; set; }
        public List<BaseFamilyHistoryDto> FamilyHistories { get; set; }
    }
}
