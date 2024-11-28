using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.Doctor;

public sealed record PatchDoctorMedicalSpecialtyCommand(Guid DoctorId, Guid MedicalSpecialtyId, bool TrackChanges, JsonPatchDocument<DoctorMedicalSpecialtyForUpdateDto> PatchDoc)
    : IRequest<(DoctorMedicalSpecialtyForUpdateDto DoctorMedicalSpecialtyToPatch, DoctorMedicalSpecialty DoctorMedicalSpecialtyEntity)>;

internal sealed class PatchDoctorMedicalSpecialtyHandler
    : IRequestHandler<PatchDoctorMedicalSpecialtyCommand, (DoctorMedicalSpecialtyForUpdateDto DoctorMedicalSpecialtyToPatch, DoctorMedicalSpecialty DoctorMedicalSpecialtyEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchDoctorMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(DoctorMedicalSpecialtyForUpdateDto DoctorMedicalSpecialtyToPatch, DoctorMedicalSpecialty DoctorMedicalSpecialtyEntity)> Handle(
        PatchDoctorMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var DoctorMedicalSpecialtyEntity = await _repository.DoctorMedicalSpecialty.GetEntityAsync(request.DoctorId, request.MedicalSpecialtyId, request.TrackChanges);
        if (DoctorMedicalSpecialtyEntity is null)
            throw new EntityNotFoundException(request.MedicalSpecialtyId);

        var DoctorMedicalSpecialtyToPatch = _mapper.Map<DoctorMedicalSpecialtyForUpdateDto>(DoctorMedicalSpecialtyEntity);
        request.PatchDoc.ApplyTo(DoctorMedicalSpecialtyToPatch);

        _mapper.Map(DoctorMedicalSpecialtyToPatch, DoctorMedicalSpecialtyEntity);
        await _repository.SaveAsync(cancellationToken);

        return (DoctorMedicalSpecialtyToPatch, DoctorMedicalSpecialtyEntity);
    }
}
