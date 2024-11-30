using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.RiskFactorHandlers;

public sealed record UpdateRiskFactorCommand(Guid Id, RiskFactorForUpdateDto RiskFactor, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateRiskFactorHandler : IRequestHandler<UpdateRiskFactorCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateRiskFactorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateRiskFactorCommand request, CancellationToken cancellationToken)
    {
        var riskFactorEntity = await _repository.RiskFactor.GetEntityAsync(request.Id, request.TrackChanges);
        if (riskFactorEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.RiskFactor, riskFactorEntity);
        _repository.RiskFactor.UpdateEntity(riskFactorEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
