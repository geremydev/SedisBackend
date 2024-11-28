using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientLabTestPrescriptionHandlers;

public sealed record DeletePatientLabTestPrescriptionCommand(Guid Id, bool TrackChanges) : IRequest<Unit>;

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
        var patientLabTestPrescription = await _repository.PatientLabTestPrescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientLabTestPrescription is null)
            throw new EntityNotFoundException(request.Id);
        patientLabTestPrescription.Status = "Inactivo";
        _repository.PatientLabTestPrescription.UpdateEntity(patientLabTestPrescription);
        await _repository.SaveAsync(cancellationToken);
    }
}
