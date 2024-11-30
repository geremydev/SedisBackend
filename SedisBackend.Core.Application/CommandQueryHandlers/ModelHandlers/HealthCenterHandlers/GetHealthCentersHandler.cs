using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthCenterHandlers;

public sealed record GetHealthCentersQuery(bool TrackChanges) : IRequest<IEnumerable<HealthCenterDto>>;

internal sealed class GetHealthCentersHandler : IRequestHandler<GetHealthCentersQuery, IEnumerable<HealthCenterDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHealthCentersHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HealthCenterDto>> Handle(GetHealthCentersQuery request, CancellationToken cancellationToken)
    {
        var HealthCenters = await _repository.HealthCenter.GetAllEntitiesAsync(request.TrackChanges);

        if (HealthCenters is null || !HealthCenters.Any())
            throw new EntitiesNotFoundException();

        var HealthCentersDto = _mapper.Map<IEnumerable<HealthCenterDto>>(HealthCenters);
        return HealthCentersDto;
    }
}
