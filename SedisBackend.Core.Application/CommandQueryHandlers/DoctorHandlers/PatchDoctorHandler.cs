using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.DoctorHandlers;

public sealed record PatchDoctorCommand(Guid Id, bool TrackChanges, JsonPatchDocument<DoctorForUpdateDto> PatchDoc)
    : IRequest<(DoctorForUpdateDto DoctorToPatch, Doctor DoctorEntity)>;

internal sealed class PatchDoctorHandler
    : IRequestHandler<PatchDoctorCommand, (DoctorForUpdateDto DoctorToPatch, Doctor DoctorEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchDoctorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(DoctorForUpdateDto DoctorToPatch, Doctor DoctorEntity)> Handle(
        PatchDoctorCommand request, CancellationToken cancellationToken)
    {
        var DoctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);
        if (DoctorEntity is null)
            throw new EntityNotFoundException(request.Id);

        var DoctorToPatch = _mapper.Map<DoctorForUpdateDto>(DoctorEntity);
        request.PatchDoc.ApplyTo(DoctorToPatch);

        _mapper.Map(DoctorToPatch, DoctorEntity);
        await _repository.SaveAsync(cancellationToken);

        return (DoctorToPatch, DoctorEntity);
    }
}
