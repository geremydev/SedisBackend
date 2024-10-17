namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History
{
    public class SaveClinicalHistoryDto
    {
        public Guid PatientId { get; set; }
        //public BasePatientDto Patient { get; set; }
        public Guid DoctorId { get; set; }
        //public BaseDoctorDto Doctor { get; set; }
        public string ReasonForVisit { get; set; }
        public string CurrentHistory { get; set; }
        public string? PhysicalExamination { get; set; }
        public string? Diagnosis { get; set; }
    }
}
