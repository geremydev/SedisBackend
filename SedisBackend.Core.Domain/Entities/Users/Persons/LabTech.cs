using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;
public class LabTech
{
    [Key]
    [ForeignKey(nameof(ApplicationUser))]
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public Guid HealthCenterId { get; set; }
    public HealthCenter HealthCenter { get; set; }
    public User ApplicationUser { get; set; }
    public ICollection<PatientLabTestPrescription> Prescriptions { get; set; }
}
