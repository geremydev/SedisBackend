using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ClinicalHistoryHandlers;

public sealed record PatchClinicalHistoryCommand(Guid Id, bool TrackChanges, JsonPatchDocument<ClinicalHistoryForUpdateDto> PatchDoc)
    : IRequest<(ClinicalHistoryForUpdateDto ClinicalHistoryToPatch, MedicalConsultation ClinicalHistoryEntity)>;

internal sealed class PatchClinicalHistoryHandler
    : IRequestHandler<PatchClinicalHistoryCommand, (ClinicalHistoryForUpdateDto ClinicalHistoryToPatch, MedicalConsultation ClinicalHistoryEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchClinicalHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(ClinicalHistoryForUpdateDto ClinicalHistoryToPatch, MedicalConsultation ClinicalHistoryEntity)> Handle(
        PatchClinicalHistoryCommand request, CancellationToken cancellationToken)
    {
        var ClinicalHistoryEntity = await _repository.ClinicalHistory.GetEntityAsync(request.Id, request.TrackChanges);
        if (ClinicalHistoryEntity is null)
            throw new EntityNotFoundException(request.Id);

        var ClinicalHistoryToPatch = _mapper.Map<ClinicalHistoryForUpdateDto>(ClinicalHistoryEntity);
        request.PatchDoc.ApplyTo(ClinicalHistoryToPatch);

        _mapper.Map(ClinicalHistoryToPatch, ClinicalHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        return (ClinicalHistoryToPatch, ClinicalHistoryEntity);
    }
}
