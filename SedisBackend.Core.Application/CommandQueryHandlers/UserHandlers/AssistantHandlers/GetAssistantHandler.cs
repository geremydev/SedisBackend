using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AssistantHandlers;

public sealed record GetAssistantQuery(Guid Id, bool TrackChanges) : IRequest<AssistantDto>;

internal sealed class GetAssistantHandler : IRequestHandler<GetAssistantQuery, AssistantDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAssistantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssistantDto> Handle(GetAssistantQuery request, CancellationToken cancellationToken)
    {
        var assistant = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);
        if (assistant is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<AssistantDto>(assistant);
    }
}
