using SedisBackend.Core.Domain.DTO.ICD11;

namespace SedisBackend.Core.Domain.Interfaces.Services.Shared;

public interface IICD11Service
{
    //Task<ICDDestinationEntity> SearchAsync(string query, IDictionary<string, string> headers, object body = null);
    Task<ICDDestinationEntity> SearchByIdAsync(string id, IDictionary<string, string> headers);
}
