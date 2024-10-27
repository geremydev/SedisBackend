namespace SedisBackend.Core.Domain.Interfaces.Services.Shared;

public interface IChatGPTService
{
    Task<string> SendQuery(string Query);
    Task<string> GetChatHistorial();
}
