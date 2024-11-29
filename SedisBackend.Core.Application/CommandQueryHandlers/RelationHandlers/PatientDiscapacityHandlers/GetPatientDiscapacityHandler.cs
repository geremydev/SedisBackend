using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientDiscapacityHandlers;

public sealed record GetPatientDiscapacityQuery(Guid PatientId, Guid DiscapacityId, bool TrackChanges) : IRequest<PatientDiscapacityDto>;

internal sealed class GetPatientDiscapacityHandler : IRequestHandler<GetPatientDiscapacityQuery, PatientDiscapacityDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientDiscapacityDto> Handle(GetPatientDiscapacityQuery request, CancellationToken cancellationToken)
    {
        var patientDiscapacities = await _repository.PatientDiscapacity.GetEntityAsync(request.PatientId,request.DiscapacityId, request.TrackChanges);
        if (patientDiscapacities is null)
            throw new EntitiesNotFoundException();

        var patientDiscapacitiesDto = _mapper.Map<PatientDiscapacityDto>(patientDiscapacities);
        return patientDiscapacitiesDto;
    }
}

