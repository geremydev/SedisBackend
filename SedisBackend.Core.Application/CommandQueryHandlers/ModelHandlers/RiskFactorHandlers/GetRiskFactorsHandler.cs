using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.RiskFactorHandlers;

public sealed record GetRiskFactorsQuery(bool TrackChanges) : IRequest<IEnumerable<RiskFactorDto>>;

internal sealed class GetRiskFactorsHandler : IRequestHandler<GetRiskFactorsQuery, IEnumerable<RiskFactorDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetRiskFactorsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RiskFactorDto>> Handle(GetRiskFactorsQuery request, CancellationToken cancellationToken)
    {
        var RiskFactors = await _repository.RiskFactor.GetAllEntitiesAsync(request.TrackChanges);

        if (RiskFactors is null || !RiskFactors.Any())
            throw new EntitiesNotFoundException();

        var RiskFactorsDto = _mapper.Map<IEnumerable<RiskFactorDto>>(RiskFactors);
        return RiskFactorsDto;
    }
}
