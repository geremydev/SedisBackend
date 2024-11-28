using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AllergyHandlers;

public record DeletePatientAllergyCommand(Guid PatientId, Guid AllergyId, bool TrackChanges) : IRequest;

internal sealed class DeletePatientAllergyHandler : IRequestHandler<DeletePatientAllergyCommand>
{
    private readonly IRepositoryManager _repository;

    public DeletePatientAllergyHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeletePatientAllergyCommand request, CancellationToken cancellationToken)
    {
        var patientAllergy = await _repository.PatientAllergy.GetEntityAsync(request.PatientId, request.AllergyId, request.TrackChanges);
        if (patientAllergy is null)
            throw new EntityNotFoundException(request.AllergyId);
        patientAllergy.Status = false;

        _repository.PatientAllergy.UpdateEntity(patientAllergy);
        await _repository.SaveAsync(cancellationToken);
    }
}
