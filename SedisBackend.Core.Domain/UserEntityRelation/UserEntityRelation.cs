namespace SedisBackend.Core.Domain.UserEntityRelation
{
    public class UserEntityRelation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EntityId { get; set; }
        public string EntityRole { get; set; } //Usando el enum de UserRole en Application
    }
}
