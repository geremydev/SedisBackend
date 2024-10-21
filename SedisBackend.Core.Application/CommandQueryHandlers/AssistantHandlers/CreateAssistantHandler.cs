using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AssistantCommandHandlers;

public sealed record CreateAssistantCommand(AssistantForCreationDto assistant) : IRequest<AssistantDto>;

internal sealed class CreateAssistantHandler : IRequestHandler<CreateAssistantCommand, AssistantDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateAssistantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssistantDto> Handle(CreateAssistantCommand request, CancellationToken cancellationToken)
    {
        var assistantEntity = _mapper.Map<Assistant>(request.assistant);
        _repository.Assistant.CreateEntity(assistantEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<AssistantDto>(assistantEntity);
    }
}
