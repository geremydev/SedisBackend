using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
public class RegistratorDto : BaseUserDto
{
    public Guid Id { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenterDto HealthCenter { get; set; }
    public bool Status { get; set; }
}
