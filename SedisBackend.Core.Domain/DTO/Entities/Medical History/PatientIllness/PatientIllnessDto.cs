﻿using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
public class PatientIllnessDto
{
    public Guid PatientId { get; set; }
    public Guid IllnessId { get; set; }
    public string DocumentURL { get; set; } //Diagnóstico Médico y así
    public DateTime? DiagnosisDate { get; set; }

    public DateTime? DischargeDate { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public Guid MedicalConsultationId { get; set; }
}