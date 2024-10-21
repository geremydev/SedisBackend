using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AssistantHandlers;

public sealed record PatchAssistantCommand(Guid Id, bool TrackChanges, JsonPatchDocument<AssistantForUpdateDto> PatchDoc)
    : IRequest<(AssistantForUpdateDto AssistantToPatch, Assistant AssistantEntity)>;

internal sealed class PatchAssistantHandler
    : IRequestHandler<PatchAssistantCommand, (AssistantForUpdateDto AssistantToPatch, Assistant AssistantEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchAssistantHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(AssistantForUpdateDto AssistantToPatch, Assistant AssistantEntity)> Handle(
        PatchAssistantCommand request, CancellationToken cancellationToken)
    {
        var AssistantEntity = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);
        if (AssistantEntity is null)
            throw new EntityNotFoundException(request.Id);

        var AssistantToPatch = _mapper.Map<AssistantForUpdateDto>(AssistantEntity);
        request.PatchDoc.ApplyTo(AssistantToPatch);

        _mapper.Map(AssistantToPatch, AssistantEntity);
        await _repository.SaveAsync(cancellationToken);

        return (AssistantToPatch, AssistantEntity);
    }
}
