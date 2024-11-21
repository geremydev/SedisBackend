﻿using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientDiscapacity : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid DiscapacityId { get; set; }
    public Discapacity Discapacity { get; set; }
    // Fecha de diagnóstico (opcional)
    public DateTime? DiagnosisDate { get; set; }

    // Nivel de severidad (leve, moderada, severa) (opcional)
    public string Severity { get; set; }
}