namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines
{
    public class SavePatientVaccineDto
    {
        public Guid PatientId { get; set; }
        public string VaccineId { get; set; }
        public int AppliedDoses { get; set; }
        public DateTime LastApplicationDate { get; set; }
    }
}
