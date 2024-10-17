namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation
{
    public class SaveUserEntityRelationDto
    {
        public Guid UserId { get; set; }
        public Guid EntityId { get; set; }
        public string EntityRole { get; set; } //Usando el enum de UserRole en Application
    }
}
