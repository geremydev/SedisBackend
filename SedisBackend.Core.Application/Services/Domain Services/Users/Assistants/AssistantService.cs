using AutoMapper;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Assistants;
using SedisBackend.Core.Application.Interfaces.Loggers;
using SedisBackend.Core.Application.Interfaces.Repositories.Base;
using SedisBackend.Core.Application.Interfaces.Services.Domain_Services.Users.Assistants;
using SedisBackend.Core.Application.Services.Base;
using SedisBackend.Core.Domain.Users.Assistants;

namespace SedisBackend.Core.Application.Services.Domain_Services.Users.Assistants
{
    public class AssistantService : GenericService<SaveAssistantDto, BaseAssistantDto, Assistant>, IAssistantService
    {
        public AssistantService(IGenericRepository<Assistant> repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }
    }
}
