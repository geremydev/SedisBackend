namespace SedisBackend.Core.Domain.Users
{
    public class BasePerson : IBaseEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime Birthdate { get; set; }
        public char Sex { get; set; }
    }
}
