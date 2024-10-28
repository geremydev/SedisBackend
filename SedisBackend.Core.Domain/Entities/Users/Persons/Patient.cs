using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SedisBackend.Core.Domain.Entities.Users.Persons;

public class Patient
{
    [Key]
    [ForeignKey(nameof(ApplicationUser))]
    public Guid Id { get; set; }
    public string? BloodType { get; set; }
    public string? BloodTypeLabResultURl { get; set; }
    public decimal? Height { get; set; }
    public decimal? Weight { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public Guid? PrimaryCarePhysicianId { get; set; }
    public ICollection<ClinicalHistory> ClinicalHistories { get; set; } = new List<ClinicalHistory>();
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<PatientAllergy> Allergies { get; set; } = new List<PatientAllergy>();
    public ICollection<PatientIllness> Illnesses { get; set; } = new List<PatientIllness>();
    public ICollection<PatientDiscapacity> Discapacities { get; set; } = new List<PatientDiscapacity>();
    public ICollection<PatientHealthInsurance> HealthInsurances { get; set; } = new List<PatientHealthInsurance>();
    public ICollection<PatientRiskFactor> RiskFactors { get; set; } = new List<PatientRiskFactor>();
    public ICollection<PatientVaccine> Vaccines { get; set; } = new List<PatientVaccine>();
    public ICollection<FamilyHistory> FamilyHistories { get; set; } = new List<FamilyHistory>();
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public User ApplicationUser { get; set; }
}
