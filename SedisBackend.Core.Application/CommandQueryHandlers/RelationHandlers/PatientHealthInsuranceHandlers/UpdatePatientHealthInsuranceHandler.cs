using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientHealthInsuranceHandlers;

public sealed record UpdatePatientHealthInsuranceCommand(Guid Id, PatientHealthInsuranceForUpdateDto PatientHealthInsurance, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientHealthInsuranceHandler : IRequestHandler<UpdatePatientHealthInsuranceCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var patientHealthInsuranceEntity = await _repository.PatientHealthInsurance.GetEntityAsync(request.PatientHealthInsurance.PatientId, request.PatientHealthInsurance.HealthInsuranceId, request.TrackChanges);
        if (patientHealthInsuranceEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.PatientHealthInsurance, patientHealthInsuranceEntity);
        _repository.PatientHealthInsurance.UpdateEntity(patientHealthInsuranceEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
