using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthCenterHandlers;

public sealed record GetHealthCenterQuery(Guid Id, bool TrackChanges) : IRequest<HealthCenterDto>;

internal sealed class GetHealthCenterHandler : IRequestHandler<GetHealthCenterQuery, HealthCenterDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHealthCenterHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HealthCenterDto> Handle(GetHealthCenterQuery request, CancellationToken cancellationToken)
    {
        var healthCenter = await _repository.HealthCenter.GetEntityAsync(request.Id, request.TrackChanges);
        if (healthCenter is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<HealthCenterDto>(healthCenter);
    }
}
