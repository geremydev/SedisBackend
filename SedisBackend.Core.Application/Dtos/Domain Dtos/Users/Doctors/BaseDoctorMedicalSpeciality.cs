using SedisBackend.Core.Domain.Users.Doctors;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class BaseMedicalSpeciality
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid MedicalSpecialityId { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
    }
}
