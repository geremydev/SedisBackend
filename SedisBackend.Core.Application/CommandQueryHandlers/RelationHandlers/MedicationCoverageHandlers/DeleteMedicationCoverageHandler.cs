using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;

public record DeleteMedicationCoverageCommand(Guid MedicationId, Guid HealthInsuranceId, bool TrackChanges) : IRequest;

internal sealed class DeleteDoctorMedicalSpecialtyHandler : IRequestHandler<DeleteMedicationCoverageCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteDoctorMedicalSpecialtyHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteMedicationCoverageCommand request, CancellationToken cancellationToken)
    {
        var medicationCoverage = await _repository.MedicationCoverage.GetEntityAsync(request.MedicationId, request.HealthInsuranceId, request.TrackChanges);
        if (medicationCoverage is null)
            throw new EntityNotFoundException(request.HealthInsuranceId);
        medicationCoverage.Status = false;
        _repository.MedicationCoverage.UpdateEntity(medicationCoverage);
        await _repository.SaveAsync(cancellationToken);
    }
}
