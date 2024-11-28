using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientHealthInsuranceHandlers;

public sealed record DeletePatientHealthInsuranceCommand(Guid patientId, Guid HealthInsuranceId, bool TrackChanges) : IRequest<Unit>;

public class DeletePatientHealthInsuranceHandler
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public DeletePatientHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(DeletePatientHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var patientHealthInsurance = await _repository.PatientHealthInsurance.GetEntityAsync(request.patientId, request.HealthInsuranceId, request.TrackChanges);
        if (patientHealthInsurance is null)
            throw new EntityNotFoundException(request.HealthInsuranceId);
        patientHealthInsurance.Status =false;
        _repository.PatientHealthInsurance.UpdateEntity(patientHealthInsurance);
        await _repository.SaveAsync(cancellationToken);
    }
}
