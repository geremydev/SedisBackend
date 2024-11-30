using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthInsuranceHandlers;

public sealed record UpdateHealthInsuranceCommand(Guid Id, HealthInsuranceForUpdateDto HealthInsurance, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateHealthInsuranceHandler : IRequestHandler<UpdateHealthInsuranceCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var healthInsuranceEntity = await _repository.HealthInsurance.GetEntityAsync(request.Id, request.TrackChanges);
        if (healthInsuranceEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.HealthInsurance, healthInsuranceEntity);
        _repository.HealthInsurance.UpdateEntity(healthInsuranceEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
