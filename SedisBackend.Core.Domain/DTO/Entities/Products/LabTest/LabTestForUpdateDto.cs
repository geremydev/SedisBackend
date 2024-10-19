namespace SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;

public record LabTestForUpdateDto
{
    public string TestName { get; set; }
    public string TestCode { get; set; }
    public LabTestForUpdateDto() { } // For default serialization
}