using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Domain.Entities.Relations;

public class PatientVaccine
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid VaccineId { get; set; }
    public Vaccine Vaccine { get; set; }
    public int AppliedDoses { get; set; }
    public DateTime LastApplicationDate { get; set; }
    public bool Status { get; set; }

}
