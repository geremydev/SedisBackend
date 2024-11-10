using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.DTO.Identity.Authentication;
public class ChangeRoleStatusRequest
{
    [Required(ErrorMessage = "Cédula requerida")]
    public string CardId { get; set; }

    [Required(ErrorMessage = "Estado requerido")]
    public bool IsActive { get; set; }
}