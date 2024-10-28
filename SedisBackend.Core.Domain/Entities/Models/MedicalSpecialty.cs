using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Entities.Models;

public class MedicalSpecialty : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } //Using enum MedicalSpecialty
    public string Description { get; set; }
    public ICollection<DoctorMedicalSpecialty> Doctors { get; set; }
}
