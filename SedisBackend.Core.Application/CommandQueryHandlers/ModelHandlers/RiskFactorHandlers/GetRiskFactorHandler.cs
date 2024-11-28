using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.RiskFactorHandlers;

public sealed record GetRiskFactorQuery(Guid Id, bool TrackChanges) : IRequest<RiskFactorDto>;

internal sealed class GetRiskFactorHandler : IRequestHandler<GetRiskFactorQuery, RiskFactorDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetRiskFactorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RiskFactorDto> Handle(GetRiskFactorQuery request, CancellationToken cancellationToken)
    {
        var riskFactor = await _repository.RiskFactor.GetEntityAsync(request.Id, request.TrackChanges);
        if (riskFactor is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<RiskFactorDto>(riskFactor);
    }
}
