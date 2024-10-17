namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients
{
    public class SavePatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public string? BloodType { get; set; }
        public string? BloodTypeLabResultURl { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public Guid? PrimaryCarePhysicianId { get; set; }
    }
}
