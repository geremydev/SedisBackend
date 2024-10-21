using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.HealthInsuranceDTO;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.CommandQueryHandlers.HealthInsuranceHandlers;

public sealed record PatchHealthInsuranceCommand(Guid Id, bool TrackChanges, JsonPatchDocument<HealthInsuranceForUpdateDto> PatchDoc)
    : IRequest<(HealthInsuranceForUpdateDto HealthInsuranceToPatch, HealthInsurance HealthInsuranceEntity)>;

internal sealed class PatchHealthInsuranceHandler
    : IRequestHandler<PatchHealthInsuranceCommand, (HealthInsuranceForUpdateDto HealthInsuranceToPatch, HealthInsurance HealthInsuranceEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(HealthInsuranceForUpdateDto HealthInsuranceToPatch, HealthInsurance HealthInsuranceEntity)> Handle(
        PatchHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var HealthInsuranceEntity = await _repository.HealthInsurance.GetEntityAsync(request.Id, request.TrackChanges);
        if (HealthInsuranceEntity is null)
            throw new EntityNotFoundException(request.Id);

        var HealthInsuranceToPatch = _mapper.Map<HealthInsuranceForUpdateDto>(HealthInsuranceEntity);
        request.PatchDoc.ApplyTo(HealthInsuranceToPatch);

        _mapper.Map(HealthInsuranceToPatch, HealthInsuranceEntity);
        await _repository.SaveAsync(cancellationToken);

        return (HealthInsuranceToPatch, HealthInsuranceEntity);
    }
}
