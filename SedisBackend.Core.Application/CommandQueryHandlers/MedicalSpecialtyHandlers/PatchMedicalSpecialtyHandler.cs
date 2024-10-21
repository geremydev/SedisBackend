using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.MedicalSpecialtyHandlers;

public sealed record PatchMedicalSpecialtyCommand(Guid Id, bool TrackChanges, JsonPatchDocument<MedicalSpecialtyForUpdateDto> PatchDoc)
    : IRequest<(MedicalSpecialtyForUpdateDto MedicalSpecialtyToPatch, MedicalSpecialty MedicalSpecialtyEntity)>;

internal sealed class PatchMedicalSpecialtyHandler
    : IRequestHandler<PatchMedicalSpecialtyCommand, (MedicalSpecialtyForUpdateDto MedicalSpecialtyToPatch, MedicalSpecialty MedicalSpecialtyEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(MedicalSpecialtyForUpdateDto MedicalSpecialtyToPatch, MedicalSpecialty MedicalSpecialtyEntity)> Handle(
        PatchMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var MedicalSpecialtyEntity = await _repository.MedicalSpecialty.GetEntityAsync(request.Id, request.TrackChanges);
        if (MedicalSpecialtyEntity is null)
            throw new EntityNotFoundException(request.Id);

        var MedicalSpecialtyToPatch = _mapper.Map<MedicalSpecialtyForUpdateDto>(MedicalSpecialtyEntity);
        request.PatchDoc.ApplyTo(MedicalSpecialtyToPatch);

        _mapper.Map(MedicalSpecialtyToPatch, MedicalSpecialtyEntity);
        await _repository.SaveAsync(cancellationToken);

        return (MedicalSpecialtyToPatch, MedicalSpecialtyEntity);
    }
}
