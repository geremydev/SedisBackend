namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class MedicalSpecialty : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //Using enum MedicalSpecialty
        public string Description { get; set; }
    }
}
