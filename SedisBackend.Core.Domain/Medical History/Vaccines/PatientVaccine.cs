using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Vaccines
{
    public class PatientVaccine : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid VaccineId { get; set; }
        public Vaccine Vaccine { get; set; }
        public int AppliedDoses { get; set; }
        public DateTime LastApplicationDate { get; set; }
    }
}
