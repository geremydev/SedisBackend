﻿using SedisBackend.Core.Domain.DTO.Entities.Appointments;
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
    public decimal Height { get; set; }
    public decimal Weight { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public Guid? PrimaryCarePhysicianId { get; set; }
    public List<ClinicalHistoryDto> ClinicalHistories { get; set; }
    public List<AppointmentDto>? Appointments { get; set; }
    public List<AllergyDto>? Allergies { get; set; }
    public List<IllnessDto>? Illnesses { get; set; }
    public List<DiscapacityDto>? Discapacities { get; set; }
    public List<RiskFactorDto>? RiskFactors { get; set; }
    public List<VaccineDto>? Vaccines { get; set; }
    public List<FamilyHistoryDto> FamilyHistories { get; set; }
}
