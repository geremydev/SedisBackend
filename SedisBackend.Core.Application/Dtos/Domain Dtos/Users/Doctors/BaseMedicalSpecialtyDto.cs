namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors
{
    public class BaseMedicalSpecialtyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //Using enum MedicalSpecialty
        public string Description { get; set; }
    }
}
