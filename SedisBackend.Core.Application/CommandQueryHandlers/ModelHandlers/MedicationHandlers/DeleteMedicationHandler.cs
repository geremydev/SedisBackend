using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicationHandlers;

public record DeleteMedicationCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteMedicationHandler : IRequestHandler<DeleteMedicationCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteMedicationHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await _repository.Medication.GetEntityAsync(request.Id, request.TrackChanges);
        if (medication is null)
            throw new EntityNotFoundException(request.Id);
        medication.Status = false;
        _repository.Medication.UpdateEntity(medication);
        await _repository.SaveAsync(cancellationToken);
    }
}
