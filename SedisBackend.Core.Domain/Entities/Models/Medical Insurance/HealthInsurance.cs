﻿using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Enums;

namespace SedisBackend.Core.Domain.Medical_Insurance;

public class HealthInsurance : IBaseEntity
{
    public Guid Id { get; set; }
    public string InsuranceName { get; set; }
    public PolicyType PolicyType { get; set; } // Usando el enum PolicyType
    public string InsuranceCompany { get; set; }
    public CoverageLevel CoverageLevel { get; set; } // Usando el enum CoverageLevel
    public ICollection<MedicationCoverage> MedicationCoverages { get; set; }
    public ICollection<PatientHealthInsurance> SubscribedPatients { get; set; }
}