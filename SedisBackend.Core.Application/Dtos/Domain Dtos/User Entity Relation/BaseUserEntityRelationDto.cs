namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation
{
    public class BaseUserEntityRelationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EntityId { get; set; }
    }
}
