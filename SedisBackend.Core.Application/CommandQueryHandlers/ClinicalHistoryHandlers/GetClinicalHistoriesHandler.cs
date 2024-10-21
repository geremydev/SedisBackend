using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ClinicalHistoryHandlers;

public sealed record GetClinicalHistoriesQuery(bool TrackChanges) : IRequest<IEnumerable<ClinicalHistoryDto>>;

internal sealed class GetClinicalHistoriesHandler : IRequestHandler<GetClinicalHistoriesQuery, IEnumerable<ClinicalHistoryDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetClinicalHistoriesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClinicalHistoryDto>> Handle(GetClinicalHistoriesQuery request, CancellationToken cancellationToken)
    {
        var ClinicalHistorys = await _repository.ClinicalHistory.GetAllEntitiesAsync(request.TrackChanges);

        if (ClinicalHistorys is null || !ClinicalHistorys.Any())
            throw new EntitiesNotFoundException();

        var ClinicalHistorysDto = _mapper.Map<IEnumerable<ClinicalHistoryDto>>(ClinicalHistorys);
        return ClinicalHistorysDto;
    }
}
