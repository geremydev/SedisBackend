using SedisBackend.Core.Domain.Health_Centers;

namespace SedisBackend.Core.Domain.Users.Admins
{
    public class Admin : BasePerson
    {
        public int HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
    }
}
