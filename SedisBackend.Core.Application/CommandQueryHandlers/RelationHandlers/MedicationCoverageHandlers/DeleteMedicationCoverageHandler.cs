using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;

public record DeleteMedicationCoverageCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteMedicationCoverageHandler : IRequestHandler<DeleteMedicationCoverageCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteMedicationCoverageHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteMedicationCoverageCommand request, CancellationToken cancellationToken)
    {
        var medicationCoverage = await _repository.MedicationCoverage.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicationCoverage is null)
            throw new EntityNotFoundException(request.Id);
        medicationCoverage.CoverageStatus = "Inactivo";
        _repository.MedicationCoverage.UpdateEntity(medicationCoverage);
        await _repository.SaveAsync(cancellationToken);
    }
}
