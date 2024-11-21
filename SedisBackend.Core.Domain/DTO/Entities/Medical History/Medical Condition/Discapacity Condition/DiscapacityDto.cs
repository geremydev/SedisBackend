﻿namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;

public record DiscapacityDto
{
    public Guid Id { get; set; }
    // Tipo de discapacidad (física, sensorial, intelectual, etc.)
    public string Type { get; set; }
    // Descripción de la discapacidad
    public string Description { get; set; }
}