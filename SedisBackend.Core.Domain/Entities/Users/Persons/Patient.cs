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
    public Doctor PrimaryCarePhysician { get; set; }
    public ICollection<MedicalConsultation>? MedicalConsultations { get; set; } 
    public ICollection<Appointment>? Appointments { get; set; }
    public ICollection<PatientAllergy>? Allergies { get; set; }
    public ICollection<PatientIllness>? Illnesses { get; set; } 
    public ICollection<PatientDiscapacity>? Discapacities { get; set; }
    public ICollection<PatientRiskFactor>? RiskFactors { get; set; } 
    public ICollection<PatientMedicationPrescription>? Medications { get; set; } 
    public ICollection<PatientHealthInsurance>? HealthInsurances { get; set; }
    public ICollection<PatientLabTestPrescription>? LabTests { get; set; } 
    public ICollection<FamilyHistory>? FamilyHistories { get; set; } 
    public ICollection<PatientVaccine>? Vaccines { get; set; } 

    public bool Status { get; set; }
    public User? ApplicationUser { get; set; }
}
