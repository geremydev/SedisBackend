using SedisBackend.Core.Domain.Health_Centers;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Admins
{
    public class BaseAdminDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public Guid HealthCenterId { get; set; }
        public HealthCenter HealthCenter { get; set; }
    }
}
