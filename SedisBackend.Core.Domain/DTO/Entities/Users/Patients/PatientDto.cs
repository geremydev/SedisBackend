using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Patients;

public record PatientDto : BaseUserDto
{
    public string BloodType { get; set; }
    public string? BloodTypeLabResultURl { get; set; }
    public decimal? Height { get; set; }
    public decimal? Weight { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public Guid? PrimaryCarePhysicianId { get; set; }
    public List<MedicalConsultationDto> ClinicalHistories { get; set; } = new List<MedicalConsultationDto>();
    public List<AppointmentDto>? Appointments { get; set; } = new List<AppointmentDto>();
    public List<AllergyDto>? Allergies { get; set; } = new List<AllergyDto>();
    public List<IllnessDto>? Illnesses { get; set; } = new List<IllnessDto>();
    public List<DiscapacityDto>? Discapacities { get; set; } = new List<DiscapacityDto>();
    public List<RiskFactorDto>? RiskFactors { get; set; } = new List<RiskFactorDto>();
    public List<VaccineDto>? Vaccines { get; set; } = new List<VaccineDto>();
    public List<FamilyHistoryDto> FamilyHistories { get; set; } = new List<FamilyHistoryDto>();
}
