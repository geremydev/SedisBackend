namespace SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;

public record LabTestDto
{
    public Guid Id { get; set; }
    public string TestName { get; set; }
    public string TestCode { get; set; }
    public bool Status { get; set; }
}
