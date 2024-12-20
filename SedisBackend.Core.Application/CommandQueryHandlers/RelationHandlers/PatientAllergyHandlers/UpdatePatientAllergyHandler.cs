using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientAllergyHandlers;

public sealed record UpdatePatientAllergyCommand(Guid Id, PatientAllergyForUpdateDto PatientAllergy, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientIllnessHandler : IRequestHandler<UpdatePatientAllergyCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientAllergyCommand request, CancellationToken cancellationToken)
    {
        var patientAllergyEntity = await _repository.PatientAllergy.GetEntityAsync(request.PatientAllergy.PatientId, request.PatientAllergy.AllergyId, request.TrackChanges);
        if (patientAllergyEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.PatientAllergy, patientAllergyEntity);
        _repository.PatientAllergy.UpdateEntity(patientAllergyEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
