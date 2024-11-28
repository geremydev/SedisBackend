using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.HealthCenterServiceHandlers;

public sealed record CreateHealthCenterServiceCommand(HealthCenterServiceForCreationDto HealthCenterService) : IRequest<HealthCenterServiceDto>;

internal sealed class CreateHealthCenterServiceHandler : IRequestHandler<CreateHealthCenterServiceCommand, HealthCenterServiceDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateHealthCenterServiceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HealthCenterServiceDto> Handle(CreateHealthCenterServiceCommand request, CancellationToken cancellationToken)
    {
        var HealthCenterService = _mapper.Map<HealthCenterServices>(request.HealthCenterService);
        _repository.HealthCenterServices.CreateEntity(HealthCenterService);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<HealthCenterServiceDto>(HealthCenterService);
    }
}
