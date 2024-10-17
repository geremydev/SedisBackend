using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Services.Base;
using SedisBackend.Core.Domain.Users.Assistants;

namespace SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Assistants
{
    public interface IAssistantService : IGenericService<SaveAssistantDto, BaseAssistantDto, Assistant>
    {
    }
}
