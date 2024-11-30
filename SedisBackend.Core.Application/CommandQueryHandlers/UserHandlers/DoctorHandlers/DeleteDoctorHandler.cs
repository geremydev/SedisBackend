using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.DoctorHandlers;

public record DeleteDoctorCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;

    public DeleteDoctorHandler(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);
        if (doctorEntity is null)
            throw new EntityNotFoundException(request.Id);
        if (doctorEntity.Status)
        {
            doctorEntity.Status = false;
            var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.RemoveFromRoleAsync(existingUser, "Doctor");
        }
        await _repository.SaveAsync(cancellationToken);
    }
}
