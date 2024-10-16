using SedisBackend.Core.Application.Dtos.ICD11;

namespace SedisBackend.Core.Application.Interfaces.Repositories.ICD11
{
    public interface IICD11Repository
    {
        Task<ICDDestinationEntity> SearchAsync(string query, IDictionary<string, string> headers, object body = null);
    }
}
