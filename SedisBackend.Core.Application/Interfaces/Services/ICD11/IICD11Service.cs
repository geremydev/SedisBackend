using SedisBackend.Core.Application.Dtos.ICD11;

namespace SedisBackend.Core.Application.Interfaces.Services.ICD11
{
    public interface IICD11Service
    {
        //Task<ICDDestinationEntity> SearchAsync(string query, IDictionary<string, string> headers, object body = null);
        Task<ICDDestinationEntity> SearchByIdAsync(string id, IDictionary<string, string> headers);
    }
}
