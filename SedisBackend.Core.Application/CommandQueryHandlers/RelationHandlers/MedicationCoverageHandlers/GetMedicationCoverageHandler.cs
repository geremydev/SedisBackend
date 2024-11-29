using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;

public sealed record GetMedicationCoverageQuery(Guid MedicationId, Guid HealthInsuranceId, bool TrackChanges) : IRequest<MedicationCoverageDto>;

internal sealed class GetDoctorMedicalSpecialtyHandler : IRequestHandler<GetMedicationCoverageQuery, MedicationCoverageDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDoctorMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicationCoverageDto> Handle(GetMedicationCoverageQuery request, CancellationToken cancellationToken)
    {
        var medicationCoverage = await _repository.MedicationCoverage.GetEntityAsync(request.MedicationId, request.HealthInsuranceId, request.TrackChanges);
        if (medicationCoverage is null)
            throw new EntityNotFoundException(request.HealthInsuranceId);

        return _mapper.Map<MedicationCoverageDto>(medicationCoverage);
    }
}
