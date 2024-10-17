namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants
{
    public class SaveAssistantDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
        public Guid HealthCenterId { get; set; }
    }
}
