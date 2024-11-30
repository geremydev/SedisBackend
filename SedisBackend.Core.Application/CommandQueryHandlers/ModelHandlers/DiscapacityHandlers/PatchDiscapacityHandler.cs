using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.DiscapacityHandlers;

public sealed record PatchDiscapacityCommand(Guid Id, bool TrackChanges, JsonPatchDocument<DiscapacityForUpdateDto> PatchDoc)
    : IRequest<(DiscapacityForUpdateDto DiscapacityToPatch, Discapacity DiscapacityEntity)>;

internal sealed class PatchDiscapacityHandler
    : IRequestHandler<PatchDiscapacityCommand, (DiscapacityForUpdateDto DiscapacityToPatch, Discapacity DiscapacityEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(DiscapacityForUpdateDto DiscapacityToPatch, Discapacity DiscapacityEntity)> Handle(
        PatchDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var DiscapacityEntity = await _repository.Discapacity.GetEntityAsync(request.Id, request.TrackChanges);
        if (DiscapacityEntity is null)
            throw new EntityNotFoundException(request.Id);

        var DiscapacityToPatch = _mapper.Map<DiscapacityForUpdateDto>(DiscapacityEntity);
        request.PatchDoc.ApplyTo(DiscapacityToPatch);

        _mapper.Map(DiscapacityToPatch, DiscapacityEntity);
        await _repository.SaveAsync(cancellationToken);

        return (DiscapacityToPatch, DiscapacityEntity);
    }
}
