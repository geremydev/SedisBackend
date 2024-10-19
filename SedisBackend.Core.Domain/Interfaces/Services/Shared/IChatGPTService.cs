namespace SedisBackend.Core.Domain.Interfaces.Services.Shared;

public interface IChatGPTService
{
    string SendQuery(string Query);
    Task<string> GetChatHistorial();
}
