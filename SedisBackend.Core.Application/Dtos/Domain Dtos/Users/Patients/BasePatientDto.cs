using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Medical_History.Allergies;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Medical_History.Family_History;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Illness_Condition;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;
using SedisBackend.Core.Domain.Medical_History.Vaccines;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients
{
    public class BasePatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public string BloodType { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public int? PrimaryCarePhysicianId { get; set; }
        public List<ClinicalHistory> ClinicalHistories { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<PatientAllergy>? Allergies { get; set; }
        public List<PatientIllness>? Illnesses { get; set; }
        public List<PatientDiscapacity>? Discapacities { get; set; }
        public List<PatientRiskFactor>? RiskFactors { get; set; }
        public List<PatientVaccine>? Vaccines { get; set; }
        public List<FamilyHistory> FamilyHistories { get; set; }
    }
}
