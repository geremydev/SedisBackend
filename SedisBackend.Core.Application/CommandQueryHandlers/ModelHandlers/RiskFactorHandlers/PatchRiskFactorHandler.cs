using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Risk_Factor_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Risk_Factor;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.RiskFactorHandlers;

public sealed record PatchRiskFactorCommand(Guid Id, bool TrackChanges, JsonPatchDocument<RiskFactorForUpdateDto> PatchDoc)
    : IRequest<(RiskFactorForUpdateDto RiskFactorToPatch, RiskFactor RiskFactorEntity)>;

internal sealed class PatchRiskFactorHandler
    : IRequestHandler<PatchRiskFactorCommand, (RiskFactorForUpdateDto RiskFactorToPatch, RiskFactor RiskFactorEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchRiskFactorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(RiskFactorForUpdateDto RiskFactorToPatch, RiskFactor RiskFactorEntity)> Handle(
        PatchRiskFactorCommand request, CancellationToken cancellationToken)
    {
        var RiskFactorEntity = await _repository.RiskFactor.GetEntityAsync(request.Id, request.TrackChanges);
        if (RiskFactorEntity is null)
            throw new EntityNotFoundException(request.Id);

        var RiskFactorToPatch = _mapper.Map<RiskFactorForUpdateDto>(RiskFactorEntity);
        request.PatchDoc.ApplyTo(RiskFactorToPatch);

        _mapper.Map(RiskFactorToPatch, RiskFactorEntity);
        await _repository.SaveAsync(cancellationToken);

        return (RiskFactorToPatch, RiskFactorEntity);
    }
}
