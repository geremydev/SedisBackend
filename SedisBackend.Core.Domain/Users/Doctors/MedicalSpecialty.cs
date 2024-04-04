namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class MedicalSpecialty
    {
        public int Id { get; set; }
        public string Name { get; set; } //Using enum MedicalSpecialty
        public string Description { get; set; }
    }
}
