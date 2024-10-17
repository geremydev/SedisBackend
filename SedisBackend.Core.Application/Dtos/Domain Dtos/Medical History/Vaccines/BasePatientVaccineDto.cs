using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines
{
    public class BasePatientVaccineDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public int AppliedDoses { get; set; }
        public DateTime LastApplicationDate { get; set; }
    }
}
