﻿namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Vaccines;

public record VaccineForCreationDto
{
    public string Name { get; set; }
    public string Disease { get; set; }
    public int Doses { get; set; } // Total number of doses required for the vaccination
    public string Laboratory { get; set; } // Manufacturer of the vaccine
}