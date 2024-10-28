using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
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
        var assistantEntity = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);

        if (assistantEntity is null)
            throw new EntityNotFoundException(request.Id);

        var assistantToPatch = _mapper.Map<AssistantForUpdateDto>(assistantEntity);

        request.PatchDoc.ApplyTo(assistantToPatch, (error) =>
        {
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        _mapper.Map(assistantToPatch, assistantEntity);

        if (assistantEntity.ApplicationUser != null)
        {
            if (assistantToPatch.FirstName != null)
                assistantEntity.ApplicationUser.FirstName = assistantToPatch.FirstName;

            if (assistantToPatch.LastName != null)
                assistantEntity.ApplicationUser.LastName = assistantToPatch.LastName;

            if (assistantToPatch.CardId != null)
                assistantEntity.ApplicationUser.CardId = assistantToPatch.CardId;

            if (assistantToPatch.IsActive != null)
                assistantEntity.ApplicationUser.IsActive = assistantToPatch.IsActive;

            if (assistantToPatch.Birthdate != null)
                assistantEntity.ApplicationUser.Birthdate = assistantToPatch.Birthdate;

            if (assistantToPatch.Email != null)
                assistantEntity.ApplicationUser.Email = assistantToPatch.Email;

            if (assistantToPatch.Sex != null)
                assistantEntity.ApplicationUser.Sex = Enum.Parse<SexEnum>(assistantToPatch.Sex, true);

            if (assistantToPatch.PhoneNumber != null)
                assistantEntity.ApplicationUser.PhoneNumber = assistantToPatch.PhoneNumber;
        }

        await _repository.SaveAsync(cancellationToken);

        return (assistantToPatch, assistantEntity);
    }
}
