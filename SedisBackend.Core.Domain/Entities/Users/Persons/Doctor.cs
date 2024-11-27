using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;

public class Doctor
{
    [Key]
    [ForeignKey(nameof(ApplicationUser))]
    public Guid Id { get; set; }
    public string? LicenseNumber { get; set; }
    public Guid CurrentlyWorkingHealthCenterId {  get; set; }
    public HealthCenter CurrentlyWorkingHealthCenter { get; set; }
    public ICollection<DoctorMedicalSpecialty> Specialties { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
    public ICollection<MedicalConsultation> MedicalConsultations { get; set; }
    public ICollection<Patient> PrimaryCarePatients { get; set; }
    public bool Status {  get; set; }
    public User ApplicationUser { get; set; }
}
