using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.IllnessHandlers;
public sealed record GetPatientIllnessesByIdQuery(Guid Id, bool TrackChanges) : IRequest<PatientIllnessDto>;

internal sealed class GetPatientIllnessByIdHandler : IRequestHandler<GetPatientIllnessesByIdQuery, PatientIllnessDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientIllnessByIdHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientIllnessDto> Handle(GetPatientIllnessesByIdQuery request, CancellationToken cancellationToken)
    {
        var patientIllnesses = await _repository.PatientIllness.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientIllnesses is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<PatientIllnessDto>(patientIllnesses);
    }
}
