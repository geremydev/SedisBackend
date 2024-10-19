﻿using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientRiskFactor : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid RiskFactorId { get; set; }
    public RiskFactor RiskFactor { get; set; }
}
