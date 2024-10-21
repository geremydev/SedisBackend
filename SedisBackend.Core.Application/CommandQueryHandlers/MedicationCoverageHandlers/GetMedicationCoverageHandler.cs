using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.MedicationCoverageCommandHandlers;

public sealed record GetMedicationCoverageQuery(Guid Id, bool TrackChanges) : IRequest<MedicationCoverageDto>;

internal sealed class GetMedicationCoverageHandler : IRequestHandler<GetMedicationCoverageQuery, MedicationCoverageDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicationCoverageHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicationCoverageDto> Handle(GetMedicationCoverageQuery request, CancellationToken cancellationToken)
    {
        var medicationCoverage = await _repository.MedicationCoverage.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicationCoverage is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<MedicationCoverageDto>(medicationCoverage);
    }
}
