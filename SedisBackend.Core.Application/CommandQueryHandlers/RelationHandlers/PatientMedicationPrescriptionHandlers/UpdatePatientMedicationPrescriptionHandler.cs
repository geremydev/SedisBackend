using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientMedicationPrescriptionHandlers;

public sealed record UpdatePatientMedicationPrescriptionCommand(Guid Id, PatientMedicationPrescriptionForUpdateDto PatientMedicationPrescription, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientMedicationPrescriptionHandler : IRequestHandler<UpdatePatientMedicationPrescriptionCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientMedicationPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientMedicationPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var patientMedicationPrescriptionEntity = await _repository.PatientMedicationPrescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientMedicationPrescriptionEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.PatientMedicationPrescription, patientMedicationPrescriptionEntity);
        _repository.PatientMedicationPrescription.UpdateEntity(patientMedicationPrescriptionEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
