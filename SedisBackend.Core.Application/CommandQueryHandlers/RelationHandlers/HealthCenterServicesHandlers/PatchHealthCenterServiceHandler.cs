using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.Doctor;

public sealed record PatchHealthCenterServiceCommand(Guid HealthCenterId, Guid ServiceId, bool TrackChanges, JsonPatchDocument<HealthCenterServiceForUpdateDto> PatchDoc)
    : IRequest<(HealthCenterServiceForUpdateDto HealthCenterServiceToPatch, HealthCenterServices HealthCenterServiceEntity)>;

internal sealed class PatchHealthCenterServiceHandler
    : IRequestHandler<PatchHealthCenterServiceCommand, (HealthCenterServiceForUpdateDto HealthCenterServiceToPatch, HealthCenterServices HealthCenterServiceEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchHealthCenterServiceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(HealthCenterServiceForUpdateDto HealthCenterServiceToPatch, HealthCenterServices HealthCenterServiceEntity)> Handle(
        PatchHealthCenterServiceCommand request, CancellationToken cancellationToken)
    {
        var HealthCenterServiceEntity = await _repository.HealthCenterServices.GetEntityAsync(request.HealthCenterId, request.ServiceId, request.TrackChanges);
        if (HealthCenterServiceEntity is null)
            throw new EntityNotFoundException(request.ServiceId);

        var HealthCenterServiceToPatch = _mapper.Map<HealthCenterServiceForUpdateDto>(HealthCenterServiceEntity);
        request.PatchDoc.ApplyTo(HealthCenterServiceToPatch);

        _mapper.Map(HealthCenterServiceToPatch, HealthCenterServiceEntity);
        await _repository.SaveAsync(cancellationToken);

        return (HealthCenterServiceToPatch, HealthCenterServiceEntity);
    }
}
