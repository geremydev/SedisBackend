using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.AdminHandlers;

public record DeleteAdminCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteLabTechHandler : IRequestHandler<DeleteAdminCommand>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;
    public DeleteLabTechHandler(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        var adminEntity = await _repository.Admin.GetEntityAsync(request.Id, request.TrackChanges);
        if (adminEntity is null)
            throw new EntityNotFoundException(request.Id);
        if (adminEntity.Status)
        {
            adminEntity.Status = false;
            var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.RemoveFromRoleAsync(existingUser, "Admin");
        }
        await _repository.SaveAsync(cancellationToken);
    }
}
