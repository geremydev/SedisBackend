using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Users;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminDto : BaseUserDto
{
    //public Guid HealthCenterId { get; set; }
    public HealthCenterDto HealthCenter { get; set; }
    public Guid Id { get; set; }
    public Guid HealthCenterId { get; set; }
    public bool Status { get; set; }
}
