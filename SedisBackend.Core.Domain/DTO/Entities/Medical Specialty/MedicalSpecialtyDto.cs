﻿namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;

public class MedicalSpecialtyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } //Using enum MedicalSpecialty
    public string Description { get; set; }
}
