namespace SedisBackend.Core.Domain.Entities.Relations;

public class UserEntityRelation : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }
    public string EntityRole { get; set; } //Usando el enum de UserRole en Application
}
