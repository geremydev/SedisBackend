using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.HealthCenterHandlers;

public sealed record PatchHealthCenterCommand(Guid Id, bool TrackChanges, JsonPatchDocument<HealthCenterForUpdateDto> PatchDoc)
    : IRequest<(HealthCenterForUpdateDto HealthCenterToPatch, HealthCenter HealthCenterEntity)>;

internal sealed class PatchHealthCenterHandler
    : IRequestHandler<PatchHealthCenterCommand, (HealthCenterForUpdateDto HealthCenterToPatch, HealthCenter HealthCenterEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchHealthCenterHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(HealthCenterForUpdateDto HealthCenterToPatch, HealthCenter HealthCenterEntity)> Handle(
        PatchHealthCenterCommand request, CancellationToken cancellationToken)
    {
        var HealthCenterEntity = await _repository.HealthCenter.GetEntityAsync(request.Id, request.TrackChanges);
        if (HealthCenterEntity is null)
            throw new EntityNotFoundException(request.Id);

        var HealthCenterToPatch = _mapper.Map<HealthCenterForUpdateDto>(HealthCenterEntity);
        request.PatchDoc.ApplyTo(HealthCenterToPatch);

        _mapper.Map(HealthCenterToPatch, HealthCenterEntity);
        await _repository.SaveAsync(cancellationToken);

        return (HealthCenterToPatch, HealthCenterEntity);
    }
}
