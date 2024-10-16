using SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class BaseDoctorDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public string LicenseNumber { get; set; }
        public List<BaseDoctorHealthCenterDto> CurrentlyWorkingHealthCenters { get; set; }
        public List<DoctorMedicalSpecialty> Specialties { get; set; }
        public List<BaseAppointmentDto> Appointments { get; set; }
        public List<BaseClinicalHistoryDto> DevelopedClinicalHistories { get; set; }
    }
}
