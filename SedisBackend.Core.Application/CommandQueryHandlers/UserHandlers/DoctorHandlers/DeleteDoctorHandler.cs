using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.DoctorHandlers;

public record DeleteDoctorCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteDoctorHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);
        if (doctor is null)
            throw new EntityNotFoundException(request.Id);

        doctor.Status = false;
        await _repository.SaveAsync(cancellationToken);
    }
}
