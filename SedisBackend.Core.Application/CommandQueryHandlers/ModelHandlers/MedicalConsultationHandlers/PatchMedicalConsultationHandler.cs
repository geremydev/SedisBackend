using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalConsultationHandlers;

public sealed record PatchMedicalConsultationCommand(Guid Id, bool TrackChanges, JsonPatchDocument<MedicalConsultationForUpdateDto> PatchDoc)
    : IRequest<(MedicalConsultationForUpdateDto MedicalConsultationToPatch, MedicalConsultation MedicalConsultation)>;

internal sealed class PatchMedicalConsultationHandler
    : IRequestHandler<PatchMedicalConsultationCommand, (MedicalConsultationForUpdateDto MedicalConsultationToPatch, MedicalConsultation MedicalConsultation)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchMedicalConsultationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(MedicalConsultationForUpdateDto MedicalConsultationToPatch, MedicalConsultation MedicalConsultation)> 
        Handle(PatchMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        var medicalConsultationEntity = await _repository.MedicalConsultation.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalConsultationEntity is null)
            throw new EntityNotFoundException(request.Id);

        var medicalConsultationToPatch = _mapper.Map<MedicalConsultationForUpdateDto>(medicalConsultationEntity);
        request.PatchDoc.ApplyTo(medicalConsultationToPatch);

        _mapper.Map(medicalConsultationToPatch, medicalConsultationEntity);
        await _repository.SaveAsync(cancellationToken);

        return (medicalConsultationToPatch, medicalConsultationEntity);
    }
}
