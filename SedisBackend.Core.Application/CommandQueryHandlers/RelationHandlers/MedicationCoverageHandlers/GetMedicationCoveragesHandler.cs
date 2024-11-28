using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;

public sealed record GetMedicationCoveragesQuery(bool TrackChanges) : IRequest<IEnumerable<MedicationCoverageDto>>;

internal sealed class GetMedicationCoveragesHandler : IRequestHandler<GetMedicationCoveragesQuery, IEnumerable<MedicationCoverageDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicationCoveragesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicationCoverageDto>> Handle(GetMedicationCoveragesQuery request, CancellationToken cancellationToken)
    {
        var MedicationCoverages = await _repository.MedicationCoverage.GetAllEntitiesAsync(request.TrackChanges);

        if (MedicationCoverages is null || !MedicationCoverages.Any())
            throw new EntitiesNotFoundException();

        var MedicationCoveragesDto = _mapper.Map<IEnumerable<MedicationCoverageDto>>(MedicationCoverages);
        return MedicationCoveragesDto;
    }
}
