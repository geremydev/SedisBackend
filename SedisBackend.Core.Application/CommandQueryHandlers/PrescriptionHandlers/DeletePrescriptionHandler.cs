using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PrescriptionCommandHandlers;

public record DeletePrescriptionCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeletePrescriptionHandler : IRequestHandler<DeletePrescriptionCommand>
{
    private readonly IRepositoryManager _repository;

    public DeletePrescriptionHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescription = await _repository.Prescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (prescription is null)
            throw new EntityNotFoundException(request.Id);

        _repository.Prescription.DeleteEntity(prescription);
        await _repository.SaveAsync(cancellationToken);
    }
}
