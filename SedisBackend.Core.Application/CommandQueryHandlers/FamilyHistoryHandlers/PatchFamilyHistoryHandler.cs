using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Family_History;

namespace SedisBackend.Core.Application.CommandQueryHandlers.FamilyHistoryHandlers;

public sealed record PatchFamilyHistoryCommand(Guid Id, bool TrackChanges, JsonPatchDocument<FamilyHistoryForUpdateDto> PatchDoc)
    : IRequest<(FamilyHistoryForUpdateDto FamilyHistoryToPatch, FamilyHistory FamilyHistoryEntity)>;

internal sealed class PatchFamilyHistoryHandler
    : IRequestHandler<PatchFamilyHistoryCommand, (FamilyHistoryForUpdateDto FamilyHistoryToPatch, FamilyHistory FamilyHistoryEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchFamilyHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(FamilyHistoryForUpdateDto FamilyHistoryToPatch, FamilyHistory FamilyHistoryEntity)> Handle(
        PatchFamilyHistoryCommand request, CancellationToken cancellationToken)
    {
        var FamilyHistoryEntity = await _repository.FamilyHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (FamilyHistoryEntity is null)
            throw new EntityNotFoundException(request.Id);

        var FamilyHistoryToPatch = _mapper.Map<FamilyHistoryForUpdateDto>(FamilyHistoryEntity);
        request.PatchDoc.ApplyTo(FamilyHistoryToPatch);

        _mapper.Map(FamilyHistoryToPatch, FamilyHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        return (FamilyHistoryToPatch, FamilyHistoryEntity);
    }
}
