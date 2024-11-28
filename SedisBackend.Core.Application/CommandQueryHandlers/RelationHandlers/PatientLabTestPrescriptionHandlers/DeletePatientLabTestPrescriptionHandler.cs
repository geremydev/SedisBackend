using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientLabTestPrescriptionHandlers;

public sealed record DeletePatientLabTestPrescriptionCommand(Guid patientId, Guid LabTestPrescriptionId, bool TrackChanges) : IRequest<Unit>;

public class DeletePatientMedicationPrescriptionHandler
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeletePatientMedicationPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(DeletePatientLabTestPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var patientLabTestPrescription = await _repository.PatientLabTestPrescription.GetEntityAsync(request.patientId, request.LabTestPrescriptionId, request.TrackChanges);
        if (patientLabTestPrescription is null)
            throw new EntityNotFoundException(request.LabTestPrescriptionId);
        patientLabTestPrescription.Status = "Inactivo";
        _repository.PatientLabTestPrescription.UpdateEntity(patientLabTestPrescription);
        await _repository.SaveAsync(cancellationToken);
    }
}
