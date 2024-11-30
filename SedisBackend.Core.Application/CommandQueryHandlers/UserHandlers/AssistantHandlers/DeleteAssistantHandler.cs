using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AssistantHandlers;

public record DeleteAssistantCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteAssistantHandler : IRequestHandler<DeleteAssistantCommand>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;

    public DeleteAssistantHandler(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task Handle(DeleteAssistantCommand request, CancellationToken cancellationToken)
    {
        var assistantEntity = await _repository.Assistant.GetEntityAsync(request.Id, request.TrackChanges);
        if (assistantEntity is null)
            throw new EntityNotFoundException(request.Id);
        if (assistantEntity.Status)
        {
            assistantEntity.Status = false;
            var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.RemoveFromRoleAsync(existingUser, "Assistant");
        }
        await _repository.SaveAsync(cancellationToken);
    }
}
