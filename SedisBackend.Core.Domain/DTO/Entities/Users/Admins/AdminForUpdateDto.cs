namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminForUpdateDto : BaseUserForUpdateDto
{
    public Guid HealthCenterId { get; set; }
    public AdminForUpdateDto()
    {

    }
}
