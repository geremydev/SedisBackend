﻿namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;

public record FamilyHistoryForUpdateDto
{
    public Guid PatientId { get; set; }
    public Guid? RelativeId { get; set; } // Nullable por si el familiar no existe
    public string Condition { get; set; }
    public string Relationship { get; set; }
    public FamilyHistoryForUpdateDto()
    {

    }
}
