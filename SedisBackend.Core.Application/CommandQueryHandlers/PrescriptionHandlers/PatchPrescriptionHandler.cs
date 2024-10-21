using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Prescriptions;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.PrescriptionHandlers;

public sealed record PatchPrescriptionCommand(Guid Id, bool TrackChanges, JsonPatchDocument<PrescriptionForUpdateDto> PatchDoc)
    : IRequest<(PrescriptionForUpdateDto PrescriptionToPatch, Prescription PrescriptionEntity)>;

internal sealed class PatchPrescriptionHandler
    : IRequestHandler<PatchPrescriptionCommand, (PrescriptionForUpdateDto PrescriptionToPatch, Prescription PrescriptionEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(PrescriptionForUpdateDto PrescriptionToPatch, Prescription PrescriptionEntity)> Handle(
        PatchPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var PrescriptionEntity = await _repository.Prescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (PrescriptionEntity is null)
            throw new EntityNotFoundException(request.Id);

        var PrescriptionToPatch = _mapper.Map<PrescriptionForUpdateDto>(PrescriptionEntity);
        request.PatchDoc.ApplyTo(PrescriptionToPatch);

        _mapper.Map(PrescriptionToPatch, PrescriptionEntity);
        await _repository.SaveAsync(cancellationToken);

        return (PrescriptionToPatch, PrescriptionEntity);
    }
}
