namespace SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;

public record LabTestForCreationDto(string TestName, string TestCode, bool Status = true);
