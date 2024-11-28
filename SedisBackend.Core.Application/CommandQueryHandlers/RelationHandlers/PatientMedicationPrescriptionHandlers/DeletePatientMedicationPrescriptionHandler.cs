using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientMedicationPrescriptionHandlers;

public sealed record DeletePatientMedicationPrescriptionCommand(Guid Id, bool TrackChanges) : IRequest<Unit>;

public class DeletePatientMedicationPrescriptionHandler
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeletePatientMedicationPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

        public async Task Handle(DeletePatientMedicationPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var patientMedicationPrescription = await _repository.PatientMedicationPrescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientMedicationPrescription is null)
            throw new EntityNotFoundException(request.Id);
        patientMedicationPrescription.Status = false;
        _repository.PatientMedicationPrescription.UpdateEntity(patientMedicationPrescription);
        await _repository.SaveAsync(cancellationToken);
    }
}
