using SedisBackend.Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;
public record UpgradeUserRequest
{
    [Required(ErrorMessage = "Cédula requerida")]
    public string CardId { get; set; }

    [Required(ErrorMessage = "Identificación del centro de salud requerida")]
    public Guid HealthCenterId { get; set; }

    [Required(ErrorMessage = "Rol requerido")]
    public RolesEnum Role { get; set; }
}
