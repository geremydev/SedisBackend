using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.IllnessHandlers;

public sealed record PatchIllnessCommand(Guid Id, bool TrackChanges, JsonPatchDocument<IllnessForUpdateDto> PatchDoc)
    : IRequest<(IllnessForUpdateDto IllnessToPatch, Illness IllnessEntity)>;

internal sealed class PatchIllnessHandler
    : IRequestHandler<PatchIllnessCommand, (IllnessForUpdateDto IllnessToPatch, Illness IllnessEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchIllnessHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IllnessForUpdateDto IllnessToPatch, Illness IllnessEntity)> Handle(
        PatchIllnessCommand request, CancellationToken cancellationToken)
    {
        var IllnessEntity = await _repository.Illness.GetEntityAsync(request.Id, request.TrackChanges);
        if (IllnessEntity is null)
            throw new EntityNotFoundException(request.Id);

        var IllnessToPatch = _mapper.Map<IllnessForUpdateDto>(IllnessEntity);
        request.PatchDoc.ApplyTo(IllnessToPatch);

        _mapper.Map(IllnessToPatch, IllnessEntity);
        await _repository.SaveAsync(cancellationToken);

        return (IllnessToPatch, IllnessEntity);
    }
}
