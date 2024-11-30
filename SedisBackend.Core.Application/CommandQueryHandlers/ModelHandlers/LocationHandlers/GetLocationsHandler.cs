using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Locations;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LocationHandlers;

public sealed record GetLocationsQuery(bool TrackChanges) : IRequest<IEnumerable<LocationDto>>;

internal sealed class GetLocationsHandler : IRequestHandler<GetLocationsQuery, IEnumerable<LocationDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLocationsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocationDto>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
    {
        var Locations = await _repository.Location.GetAllEntitiesAsync(request.TrackChanges);

        if (Locations is null || !Locations.Any())
            throw new EntitiesNotFoundException();

        var LocationsDto = _mapper.Map<IEnumerable<LocationDto>>(Locations);
        return LocationsDto;
    }
}
