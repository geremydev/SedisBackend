using AutoMapper;
using MediatR;
using SedisBackend.Core.Application.CommandHandlers.IllnessCommandHandlers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.IllnessHandlers;
public sealed record GetPatientIllnessesQuery(Guid Id, bool TrackChanges) : IRequest<IEnumerable<PatientIllnessDto>>;

internal sealed class GetPatientIllnessesHandler : IRequestHandler<GetPatientIllnessesQuery, IEnumerable<PatientIllnessDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientIllnessesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientIllnessDto>> Handle(GetPatientIllnessesQuery request, CancellationToken cancellationToken)
    {
        var patientIllnesses = await _repository.PatientIllness.GetAllPatientsIllnessesAsync(request.Id, request.TrackChanges);
        if (patientIllnesses is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<IEnumerable<PatientIllnessDto>>(patientIllnesses);
    }
}
