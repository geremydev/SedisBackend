using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PatientCommandHandlers;

public record DeletePatientCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeletePatientHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IRepositoryManager _repository;

    public DeletePatientHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);
        if (patient is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Patient.DeleteEntity(patient);
        await _repository.SaveAsync(cancellationToken);
    }
}
