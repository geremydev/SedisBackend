using MediatR;
using Microsoft.AspNetCore.Identity;
using SedisBackend.Core.Domain.Entities.Users;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.PatientHandlers;

public record DeletePatientCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeletePatientHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IRepositoryManager _repository;
    private readonly UserManager<User> _userManager;
    public DeletePatientHandler(IRepositoryManager repository, UserManager<User> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patientEntity = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientEntity is null)
            throw new EntityNotFoundException(request.Id);
        if (patientEntity.Status)
        {
            patientEntity.Status = false;
            var existingUser = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.RemoveFromRoleAsync(existingUser, "Patient");
        }
        await _repository.SaveAsync(cancellationToken);
    }
}
