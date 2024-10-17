namespace SedisBackend.Core.Application.Interfaces.Services.Shared_Services
{
    public interface IChatGPTService
    {
        string SendQuery(string Query);
        Task<string> GetChatHistorial();
    }
}
