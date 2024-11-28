using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;

public sealed record UpdateMedicationCoverageCommand(Guid MedicationId, Guid HealthInsuranceId, MedicationCoverageForUpdateDto MedicationCoverage, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateDoctorMedicalSpecialtyHandler : IRequestHandler<UpdateMedicationCoverageCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateDoctorMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMedicationCoverageCommand request, CancellationToken cancellationToken)
    {
        var medicationCoverageEntity = await _repository.MedicationCoverage.GetEntityAsync(request.MedicationId, request.HealthInsuranceId, request.TrackChanges);
        if (medicationCoverageEntity is null)
            throw new EntityNotFoundException(request.HealthInsuranceId);

        _mapper.Map(request.MedicationCoverage, medicationCoverageEntity);
        _repository.MedicationCoverage.UpdateEntity(medicationCoverageEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
