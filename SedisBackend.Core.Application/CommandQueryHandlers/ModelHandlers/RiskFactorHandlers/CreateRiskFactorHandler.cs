using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.RiskFactorHandlers;

public sealed record CreateRiskFactorCommand(RiskFactorForCreationDto riskFactor) : IRequest<RiskFactorDto>;

internal sealed class CreateRiskFactorHandler : IRequestHandler<CreateRiskFactorCommand, RiskFactorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateRiskFactorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RiskFactorDto> Handle(CreateRiskFactorCommand request, CancellationToken cancellationToken)
    {
        var riskFactorEntity = _mapper.Map<RiskFactor>(request.riskFactor);
        _repository.RiskFactor.CreateEntity(riskFactorEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<RiskFactorDto>(riskFactorEntity);
    }
}
