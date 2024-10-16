namespace SedisBackend.Core.Application.Dtos.ICD11
{
    public class ICDApiResponse
    {
        public List<ICDDestinationEntity> DestinationEntities { get; set; }
        public bool Error { get; set; }
    }

    public class ICDDestinationEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
