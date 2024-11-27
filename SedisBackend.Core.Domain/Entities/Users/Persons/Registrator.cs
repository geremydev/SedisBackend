using SedisBackend.Core.Domain.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;
public class Registrator
{
    [Key]
    [ForeignKey(nameof(ApplicationUser))]
    public Guid Id { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public bool Status { get; set; }
    public User ApplicationUser { get; set; }
}
