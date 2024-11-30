using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record GetPatientIllnesessQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientIllnessDto>>;

internal sealed class GetPatientIllnessHandler : IRequestHandler<GetPatientIllnesessQuery, IEnumerable<PatientIllnessDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientIllnessDto>> Handle(GetPatientIllnesessQuery request, CancellationToken cancellationToken)
    {
        var patientAllergies = await _repository.PatientIllness.GetByPatient(request.PatientId, request.TrackChanges);
        if (patientAllergies is null || !patientAllergies.Any())
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<IEnumerable<PatientIllnessDto>>(patientAllergies);
        return patientAllergiesDot;
    }
}

