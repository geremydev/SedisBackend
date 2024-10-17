namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class SaveDoctorMedicalSpecialtyDto
    {
        public Guid DoctorId { get; set; }
        public Guid MedicalSpecialityId { get; set; }
    }
}
