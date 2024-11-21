using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.Entities.Users;
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
    private readonly UserManager<User> _userManager;
    public PatchAssistantHandler(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<(AssistantForUpdateDto AssistantToPatch, Assistant AssistantEntity)> Handle(
        PatchAssistantCommand request, CancellationToken cancellationToken)
    {
        var assistantEntity = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);
        var originalIsActive = assistantEntity.IsActive;
        if (assistantEntity is null)
            throw new EntityNotFoundException(request.Id);

        var assistantToPatch = _mapper.Map<AssistantForUpdateDto>(assistantEntity);

        request.PatchDoc.ApplyTo(assistantToPatch, (error) =>
        {
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        _mapper.Map(assistantToPatch, assistantEntity);
        assistantEntity.IsActive = originalIsActive;

        if (assistantEntity.ApplicationUser != null)
        {
            if (assistantEntity.IsActive != null)
            {
                if (assistantEntity.IsActive != assistantToPatch.IsActive)
                {
                    assistantEntity.IsActive = assistantToPatch.IsActive;

                    var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == assistantEntity.Id, cancellationToken);

                    if(assistantEntity.IsActive) 
                        await _userManager.AddToRoleAsync(currentUser, "Assistant");
                    else
                        await _userManager.RemoveFromRoleAsync(currentUser, "Assistant");
                }   
            }
        }

        await _repository.SaveAsync(cancellationToken);

        return (assistantToPatch, assistantEntity);
    }
}
