using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.LabTechHandlers;

public record DeleteLabTechCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteRegistratorHandler : IRequestHandler<DeleteLabTechCommand>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;


    public DeleteRegistratorHandler(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task Handle(DeleteLabTechCommand request, CancellationToken cancellationToken)
    {
        var labTechEntity = await _repository.LabTech.GetEntityAsync(request.Id, request.TrackChanges);
        if (labTechEntity is null)
            throw new EntityNotFoundException(request.Id);
        if (labTechEntity.Status)
        {
            labTechEntity.Status = false;
            var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.RemoveFromRoleAsync(existingUser, "LabTech");
        }
        await _repository.SaveAsync(cancellationToken);
    }
}
