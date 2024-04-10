namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.User_Entity_Relation
{
    public class SaveUserEntityRelation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EntityId { get; set; }
        public string EntityRole { get; set; } //Usando el enum de UserRole en Application
    }
}
