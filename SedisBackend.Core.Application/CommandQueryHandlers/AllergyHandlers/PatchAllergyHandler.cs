using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Allergies;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AllergyHandlers;

public sealed record PatchAllergyCommand(Guid Id, bool TrackChanges, JsonPatchDocument<AllergyForUpdateDto> PatchDoc)
    : IRequest<(AllergyForUpdateDto AllergyToPatch, Allergy AllergyEntity)>;

internal sealed class PatchAllergyHandler
    : IRequestHandler<PatchAllergyCommand, (AllergyForUpdateDto AllergyToPatch, Allergy AllergyEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchAllergyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(AllergyForUpdateDto AllergyToPatch, Allergy AllergyEntity)> Handle(
        PatchAllergyCommand request, CancellationToken cancellationToken)
    {
        var AllergyEntity = await _repository.Allergy.GetEntityAsync(request.Id, request.TrackChanges);
        if (AllergyEntity is null)
            throw new EntityNotFoundException(request.Id);

        var AllergyToPatch = _mapper.Map<AllergyForUpdateDto>(AllergyEntity);
        request.PatchDoc.ApplyTo(AllergyToPatch);

        _mapper.Map(AllergyToPatch, AllergyEntity);
        await _repository.SaveAsync(cancellationToken);

        return (AllergyToPatch, AllergyEntity);
    }
}
