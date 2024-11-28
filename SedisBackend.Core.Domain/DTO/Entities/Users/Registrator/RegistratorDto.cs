using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Users;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
public class RegistratorDto
{
    public Guid Id { get; set; }
    public Guid HealthCenterId { get; set; }
    public bool Status { get; set; }
}
