using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Locations;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.LocationCommandHandlers;

public sealed record UpdateLocationCommand(Guid Id, LocationForUpdateDto Location, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateLocationHandler : IRequestHandler<UpdateLocationCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateLocationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var locationEntity = await _repository.Location.GetEntityAsync(request.Id, request.TrackChanges);
        if (locationEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Location, locationEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
