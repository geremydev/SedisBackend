using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthCenterHandlers;

public sealed record UpdateHealthCenterCommand(Guid Id, HealthCenterForUpdateDto HealthCenter, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateHealthCenterHandler : IRequestHandler<UpdateHealthCenterCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateHealthCenterHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateHealthCenterCommand request, CancellationToken cancellationToken)
    {
        var healthCenterEntity = await _repository.HealthCenter.GetEntityAsync(request.Id, request.TrackChanges);
        if (healthCenterEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.HealthCenter, healthCenterEntity);
        _repository.HealthCenter.UpdateEntity(healthCenterEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
