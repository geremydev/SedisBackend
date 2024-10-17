namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class DoctorMedicalSpecialty : IBaseEntity
    {
        //n->n relationship table between Doctor and MedicalSpecialisation
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public Guid MedicalSpecialtyId { get; set; }
        public MedicalSpecialty MedicalSpecialty { get; set; }
    }
}
