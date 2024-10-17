namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions
{
    public class Illness : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
