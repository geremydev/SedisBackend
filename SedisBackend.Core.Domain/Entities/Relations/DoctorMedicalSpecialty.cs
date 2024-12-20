﻿using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Users.Persons;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class DoctorMedicalSpecialty 
{
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid MedicalSpecialtyId { get; set; }
    public MedicalSpecialty MedicalSpecialty { get; set; }
    public bool Status { get; set; }
}
