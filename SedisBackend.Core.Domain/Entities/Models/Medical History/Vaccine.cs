using SedisBackend.Core.Domain.Entities;
using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Medical_History.Vaccines;

public class Vaccine : IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Doses { get; set; } // Total number of doses required for the vaccination
    public string Laboratory { get; set; } // Manufacturer of the vaccine
    public ICollection<PatientVaccine> PatientVaccines { get; set; }
}
