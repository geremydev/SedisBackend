using SedisBackend.Core.Domain.Entities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;

public class Admin
{
    [Key]
    [ForeignKey(nameof(ApplicationUser))]
    public Guid Id { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public bool Status { get; set; }
    public User ApplicationUser { get; set; }
}
