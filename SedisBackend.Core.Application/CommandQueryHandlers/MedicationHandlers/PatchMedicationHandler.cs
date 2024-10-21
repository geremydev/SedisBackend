using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.MedicationHandlers;

public sealed record PatchMedicationCommand(Guid Id, bool TrackChanges, JsonPatchDocument<MedicationForUpdateDto> PatchDoc)
    : IRequest<(MedicationForUpdateDto MedicationToPatch, Medication MedicationEntity)>;

internal sealed class PatchMedicationHandler
    : IRequestHandler<PatchMedicationCommand, (MedicationForUpdateDto MedicationToPatch, Medication MedicationEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchMedicationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(MedicationForUpdateDto MedicationToPatch, Medication MedicationEntity)> Handle(
        PatchMedicationCommand request, CancellationToken cancellationToken)
    {
        var MedicationEntity = await _repository.Medication.GetEntityAsync(request.Id, request.TrackChanges);
        if (MedicationEntity is null)
            throw new EntityNotFoundException(request.Id);

        var MedicationToPatch = _mapper.Map<MedicationForUpdateDto>(MedicationEntity);
        request.PatchDoc.ApplyTo(MedicationToPatch);

        _mapper.Map(MedicationToPatch, MedicationEntity);
        await _repository.SaveAsync(cancellationToken);

        return (MedicationToPatch, MedicationEntity);
    }
}
