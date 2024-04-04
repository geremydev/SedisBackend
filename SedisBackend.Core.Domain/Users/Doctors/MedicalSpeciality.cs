namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class MedicalSpeciality
    {
        public int Id { get; set; }
        public string Name { get; set; } //Using enum MedicalSpeciality
        public string Description { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
