namespace SedisBackend.Core.Domain.DTO.Entities.Products.LabTest;

public class LabTestForCreationDto()
{
    public string TestName { get; set; }
    public string TestCode { get; set; }
    public bool Status { get; set; } = true;
}
