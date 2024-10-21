using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminDto : BaseUserDto
{
    public Guid HealthCenterId { get; set; }
    public HealthCenterDto HealthCenter { get; set; }
}
