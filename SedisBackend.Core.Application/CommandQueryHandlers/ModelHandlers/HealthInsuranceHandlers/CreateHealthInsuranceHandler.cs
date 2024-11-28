using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthInsuranceHandlers;

public sealed record CreateHealthInsuranceCommand(HealthInsuranceForCreationDto healthInsurance) : IRequest<HealthInsuranceDto>;

internal sealed class CreateHealthInsuranceHandler : IRequestHandler<CreateHealthInsuranceCommand, HealthInsuranceDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HealthInsuranceDto> Handle(CreateHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var healthInsuranceEntity = _mapper.Map<HealthInsurance>(request.healthInsurance);
        _repository.HealthInsurance.CreateEntity(healthInsuranceEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<HealthInsuranceDto>(healthInsuranceEntity);
    }
}
