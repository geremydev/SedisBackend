using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;

public class Doctor : User
{
    public string LicenseNumber { get; set; }
    public ICollection<DoctorHealthCenter> CurrentlyWorkingHealthCenters { get; set; }
    public ICollection<DoctorMedicalSpecialty> Specialties { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<ClinicalHistory> DevelopedClinicalHistories { get; set; }
}
