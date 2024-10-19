namespace SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;

public record MedicalSpecialtyForCreationDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}
