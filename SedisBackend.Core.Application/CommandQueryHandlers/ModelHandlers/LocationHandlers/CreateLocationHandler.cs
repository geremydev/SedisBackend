using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Locations;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LocationHandlers;

public sealed record CreateLocationCommand(LocationForCreationDto location) : IRequest<LocationDto>;

internal sealed class CreateLocationHandler : IRequestHandler<CreateLocationCommand, LocationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateLocationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LocationDto> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var locationEntity = _mapper.Map<Location>(request.location);
        _repository.Location.CreateEntity(locationEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<LocationDto>(locationEntity);
    }
}
