using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.HealthInsuranceHandlers;

public sealed record GetHealthInsurancesQuery(bool TrackChanges) : IRequest<IEnumerable<HealthInsuranceDto>>;

internal sealed class GetHealthInsurancesHandler : IRequestHandler<GetHealthInsurancesQuery, IEnumerable<HealthInsuranceDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHealthInsurancesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HealthInsuranceDto>> Handle(GetHealthInsurancesQuery request, CancellationToken cancellationToken)
    {
        var HealthInsurances = await _repository.HealthInsurance.GetAllEntitiesAsync(request.TrackChanges);

        if (HealthInsurances is null || !HealthInsurances.Any())
            throw new EntitiesNotFoundException();

        var HealthInsurancesDto = _mapper.Map<IEnumerable<HealthInsuranceDto>>(HealthInsurances);
        return HealthInsurancesDto;
    }
}
