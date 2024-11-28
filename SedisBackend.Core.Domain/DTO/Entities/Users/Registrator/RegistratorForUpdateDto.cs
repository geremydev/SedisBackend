using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Users;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Registrator;
public class RegistratorForUpdateDto
{
    public Guid HealthCenterId { get; set; }
    public bool Status { get; set; }
    public RegistratorForUpdateDto()
    {
        
    }
}
