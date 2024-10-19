namespace SedisBackend.Core.Domain.DTO.Entities.Users.Admins;

public record AdminDto : BaseUserDto
{
    public Guid HealthCenterId { get; set; }
    //public HealthCenter HealthCenter { get; set; }
}
