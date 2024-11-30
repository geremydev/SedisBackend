using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.FamilyHistoryHandlers;

public sealed record GetFamilyHistoriesQuery(bool TrackChanges) : IRequest<IEnumerable<FamilyHistoryDto>>;

internal sealed class GetFamilyHistoriesHandler : IRequestHandler<GetFamilyHistoriesQuery, IEnumerable<FamilyHistoryDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetFamilyHistoriesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FamilyHistoryDto>> Handle(GetFamilyHistoriesQuery request, CancellationToken cancellationToken)
    {
        var FamilyHistorys = await _repository.FamilyHistory.GetAllEntitiesAsync(request.TrackChanges);

        if (FamilyHistorys is null || !FamilyHistorys.Any())
            throw new EntitiesNotFoundException();

        var FamilyHistorysDto = _mapper.Map<IEnumerable<FamilyHistoryDto>>(FamilyHistorys);
        return FamilyHistorysDto;
    }
}
