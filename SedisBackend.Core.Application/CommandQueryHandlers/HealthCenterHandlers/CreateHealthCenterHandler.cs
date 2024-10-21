using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.HealthCenterCommandHandlers;

public sealed record CreateHealthCenterCommand(HealthCenterForCreationDto healthCenter) : IRequest<HealthCenterDto>;

internal sealed class CreateHealthCenterHandler : IRequestHandler<CreateHealthCenterCommand, HealthCenterDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateHealthCenterHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HealthCenterDto> Handle(CreateHealthCenterCommand request, CancellationToken cancellationToken)
    {
        var healthCenterEntity = _mapper.Map<HealthCenter>(request.healthCenter);
        _repository.HealthCenter.CreateEntity(healthCenterEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<HealthCenterDto>(healthCenterEntity);
    }
}
