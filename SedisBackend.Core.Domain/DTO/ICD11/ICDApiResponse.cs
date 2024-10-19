namespace SedisBackend.Core.Domain.DTO.ICD11;

public class ICDApiResponse
{
    public bool Error { get; set; }
}

public class ICDDestinationEntity
{
    public string Id { get; set; }
    public string FullUrl { get; set; }
    public string SpanishBrowserUrl { get; set; }
    public string Title { get; set; }
    public string Definition { get; set; }
    public string LongDefinition { get; set; }
}
