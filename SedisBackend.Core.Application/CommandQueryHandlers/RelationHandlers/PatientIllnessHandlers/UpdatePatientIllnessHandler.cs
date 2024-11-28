using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record UpdatePatientIllnessCommand(Guid Id, PatientIllnessForUpdateDto PatientIllness, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientHealthInsuranceHandler : IRequestHandler<UpdatePatientIllnessCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientIllnessCommand request, CancellationToken cancellationToken)
    {
        var patientIllnessEntity = await _repository.PatientIllness.GetEntityAsync(request.PatientIllness.PatientId, request.PatientIllness.IllnessId, request.TrackChanges);
        if (patientIllnessEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.PatientIllness, patientIllnessEntity);
        _repository.PatientIllness.UpdateEntity(patientIllnessEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
