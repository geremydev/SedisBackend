using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Locations;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.LocationHandlers;

public sealed record PatchLocationCommand(Guid Id, bool TrackChanges, JsonPatchDocument<LocationForUpdateDto> PatchDoc)
    : IRequest<(LocationForUpdateDto LocationToPatch, Location LocationEntity)>;

internal sealed class PatchLocationHandler
    : IRequestHandler<PatchLocationCommand, (LocationForUpdateDto LocationToPatch, Location LocationEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchLocationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(LocationForUpdateDto LocationToPatch, Location LocationEntity)> Handle(
        PatchLocationCommand request, CancellationToken cancellationToken)
    {
        var LocationEntity = await _repository.Location.GetEntityAsync(request.Id, request.TrackChanges);
        if (LocationEntity is null)
            throw new EntityNotFoundException(request.Id);

        var LocationToPatch = _mapper.Map<LocationForUpdateDto>(LocationEntity);
        request.PatchDoc.ApplyTo(LocationToPatch);

        _mapper.Map(LocationToPatch, LocationEntity);
        await _repository.SaveAsync(cancellationToken);

        return (LocationToPatch, LocationEntity);
    }
}
