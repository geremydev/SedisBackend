using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientHealthInsuranceHandlers;
public sealed record GetPatientHealthInsuranceByIdQuery(Guid PatientId, Guid HealthInsuranceId, bool TrackChanges) : IRequest<PatientHealthInsuranceDto>;

public sealed class GetPatientHealthInsuranceByIdHandler : IRequestHandler<GetPatientHealthInsuranceByIdQuery, PatientHealthInsuranceDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientHealthInsuranceByIdHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientHealthInsuranceDto> Handle(GetPatientHealthInsuranceByIdQuery request, CancellationToken cancellationToken)
    {
        var patientHealthInsurance = await _repository.PatientHealthInsurance.GetEntityAsync(request.PatientId, request.HealthInsuranceId, request.TrackChanges);
        if (patientHealthInsurance is null)
            throw new EntitiesNotFoundException();

        var patientHealthInsuranceDto = _mapper.Map<PatientHealthInsuranceDto>(patientHealthInsurance);
        return patientHealthInsuranceDto;
    }
}
