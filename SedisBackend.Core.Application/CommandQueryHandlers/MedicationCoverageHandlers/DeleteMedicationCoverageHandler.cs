using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.MedicationCoverageCommandHandlers;

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

        _repository.MedicationCoverage.DeleteEntity(medicationCoverage);
        await _repository.SaveAsync(cancellationToken);
    }
}
