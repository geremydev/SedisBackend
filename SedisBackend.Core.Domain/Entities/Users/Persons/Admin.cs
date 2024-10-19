using SedisBackend.Core.Domain.Entities.Models;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;

public class Admin : User
{
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
}
