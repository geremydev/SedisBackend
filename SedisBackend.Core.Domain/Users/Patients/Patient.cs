using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Domain.Users.Patients
{
    public class Patient : BasePerson
    {
        public string? BloodType { get; set; }
        public string? BloodTypeLabResultURl { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public Guid? PrimaryCarePhysicianId { get; set; }
        public ICollection<ClinicalHistory> ClinicalHistories { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<PatientAllergy>? Allergies { get; set; }
        public ICollection<PatientIllness>? Illnesses { get; set; }
        public ICollection<PatientDiscapacity>? Discapacities { get; set; }
        public ICollection<PatientRiskFactor>? RiskFactors { get; set; }
        public ICollection<PatientVaccine>? Vaccines { get; set; }
        public ICollection<FamilyHistory> FamilyHistories { get; set; }
    }
}
