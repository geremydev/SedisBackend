using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.RegistratorHandlers;

public record DeleteRegistratorCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteRegistratorHandler : IRequestHandler<DeleteRegistratorCommand>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;
    public DeleteRegistratorHandler(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task Handle(DeleteRegistratorCommand request, CancellationToken cancellationToken)
    {
        var registratorEntity = await _repository.Registrator.GetEntityAsync(request.Id, request.TrackChanges);
        if (registratorEntity is null)
            throw new EntityNotFoundException(request.Id);
        if (registratorEntity.Status)
        {
            registratorEntity.Status = false;
            var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.RemoveFromRoleAsync(existingUser, "Registrator");
        }
        await _repository.SaveAsync(cancellationToken);
    }
}
