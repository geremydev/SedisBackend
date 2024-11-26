﻿using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
public class PatientIllnessDto : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid IllnessId { get; set; }
    public Illness Illness { get; set; }
    public string DocumentURL { get; set; }
    public DateTime? DiagnosisDate { get; set; }

    public DateTime? DischargeDate { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
}
