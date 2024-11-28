using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientHealthInsuranceHandlers;

public sealed record GetPatientHealthInsurancesQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientHealthInsuranceDto>>;

internal sealed class GetPatientHealthInsuranceHandler : IRequestHandler<GetPatientHealthInsurancesQuery, IEnumerable<PatientHealthInsuranceDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientHealthInsuranceDto>> Handle(GetPatientHealthInsurancesQuery request, CancellationToken cancellationToken)
    {
        var patientHealthInsurances = await _repository.PatientHealthInsurance.GetByPatient(request.PatientId, request.TrackChanges);
        if (patientHealthInsurances is null || !patientHealthInsurances.Any())
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<IEnumerable<PatientHealthInsuranceDto>>(patientHealthInsurances);
        return patientAllergiesDot;
    }
}

