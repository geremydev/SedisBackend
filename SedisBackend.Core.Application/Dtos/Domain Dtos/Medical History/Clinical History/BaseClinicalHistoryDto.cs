using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History
{
    public class BaseClinicalHistoryDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public BasePatientDto Patient { get; set; }
        public Guid DoctorId { get; set; }
        public BaseDoctorDto Doctor { get; set; }
        public string ReasonForVisit { get; set; }
        public string CurrentHistory { get; set; }
        public string? PhysicalExamination { get; set; }
        public string? Diagnosis { get; set; }
    }
}
