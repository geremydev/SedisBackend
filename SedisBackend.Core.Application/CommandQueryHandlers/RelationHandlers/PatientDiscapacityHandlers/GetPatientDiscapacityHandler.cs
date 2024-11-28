using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientDiscapacityHandlers;

public sealed record GetPatientIllnesessQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientDiscapacityDto>>;

internal sealed class GetPatientDiscapacityHandler : IRequestHandler<GetPatientIllnesessQuery, IEnumerable<PatientDiscapacityDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDiscapacityDto>> Handle(GetPatientIllnesessQuery request, CancellationToken cancellationToken)
    {
        var patientIllnesess = await _repository.PatientDiscapacity.GetPatientDiscapacities(request.PatientId, request.TrackChanges);
        if (patientIllnesess is null || !patientIllnesess.Any())
            throw new EntitiesNotFoundException();

        var patientIllnesessDot = _mapper.Map<IEnumerable<PatientDiscapacityDto>>(patientIllnesess);
        return patientIllnesessDot;
    }
}

