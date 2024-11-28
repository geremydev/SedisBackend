using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AssistantHandlers;

public sealed record GetAssistantsQuery(bool TrackChanges) : IRequest<IEnumerable<AssistantDto>>;

internal sealed class GetAssistantsHandler : IRequestHandler<GetAssistantsQuery, IEnumerable<AssistantDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAssistantsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AssistantDto>> Handle(GetAssistantsQuery request, CancellationToken cancellationToken)
    {
        var Assistants = await _repository.Assistant.GetAllEntitiesAsync(request.TrackChanges);

        if (Assistants is null || !Assistants.Any())
            throw new EntitiesNotFoundException();

        var AssistantsDto = _mapper.Map<IEnumerable<AssistantDto>>(Assistants);
        return AssistantsDto;
    }
}
