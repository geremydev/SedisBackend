using SedisBackend.Core.Domain.Health_Centers;

namespace SedisBackend.Core.Domain.Users.Assistants
{
    public class Assistant : BasePerson
    {
        public Guid HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
    }
}
