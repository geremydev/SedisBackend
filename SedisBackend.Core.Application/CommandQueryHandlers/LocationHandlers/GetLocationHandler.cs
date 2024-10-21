using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Locations;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.LocationCommandHandlers;

public sealed record GetLocationQuery(Guid Id, bool TrackChanges) : IRequest<LocationDto>;

internal sealed class GetLocationHandler : IRequestHandler<GetLocationQuery, LocationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetLocationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LocationDto> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var location = await _repository.Location.GetEntityAsync(request.Id, request.TrackChanges);
        if (location is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<LocationDto>(location);
    }
}
