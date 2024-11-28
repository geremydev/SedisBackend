using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientLabTestPrescriptionHandlers;

public sealed record UpdatePatientLabTestPrescriptionCommand(Guid PatientId, Guid LabTestId, PatientLabTestPrescriptionForUpdateDto PatientLabTestPrescription, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientLabTestPrescriptionHandler : IRequestHandler<UpdatePatientLabTestPrescriptionCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientLabTestPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientLabTestPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var patientLabTestPrescriptionEntity = await _repository.PatientLabTestPrescription.GetEntityAsync(request.PatientLabTestPrescription.PatientId, request.PatientLabTestPrescription.LabTestId, request.TrackChanges);
        if (patientLabTestPrescriptionEntity is null)
            throw new EntityNotFoundException(request.LabTestId);

        _mapper.Map(request.PatientLabTestPrescription, patientLabTestPrescriptionEntity);
        _repository.PatientLabTestPrescription.UpdateEntity(patientLabTestPrescriptionEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
