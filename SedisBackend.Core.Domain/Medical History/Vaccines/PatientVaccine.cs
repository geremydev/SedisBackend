using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Vaccines
{
    public class PatientVaccine
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public string VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public int AppliedDoses { get; set; }
        public DateTime LastApplicationDate { get; set; }
    }
}
