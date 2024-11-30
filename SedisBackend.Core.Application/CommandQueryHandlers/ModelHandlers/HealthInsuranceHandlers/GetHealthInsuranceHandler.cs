using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthInsuranceHandlers;

public sealed record GetHealthInsuranceQuery(Guid Id, bool TrackChanges) : IRequest<HealthInsuranceDto>;

internal sealed class GetHealthInsuranceHandler : IRequestHandler<GetHealthInsuranceQuery, HealthInsuranceDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HealthInsuranceDto> Handle(GetHealthInsuranceQuery request, CancellationToken cancellationToken)
    {
        var healthInsurance = await _repository.HealthInsurance.GetEntityAsync(request.Id, request.TrackChanges);
        if (healthInsurance is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<HealthInsuranceDto>(healthInsurance);
    }
}
