using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.HealthCenterServiceHandlers;

public sealed record UpdateHealthCenterServiceCommand(Guid HealthCenterId, Guid ServiceId, HealthCenterServiceForUpdateDto HealthCenterService, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateHealthCenterServiceHandler : IRequestHandler<UpdateHealthCenterServiceCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateHealthCenterServiceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateHealthCenterServiceCommand request, CancellationToken cancellationToken)
    {
        var HealthCenterServiceEntity = await _repository.HealthCenterServices.GetEntityAsync(request.HealthCenterId, request.ServiceId, request.TrackChanges);
        if (HealthCenterServiceEntity is null)
            throw new EntityNotFoundException(request.ServiceId);

        _mapper.Map(request.HealthCenterService, HealthCenterServiceEntity);
        _repository.HealthCenterServices.UpdateEntity(HealthCenterServiceEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
