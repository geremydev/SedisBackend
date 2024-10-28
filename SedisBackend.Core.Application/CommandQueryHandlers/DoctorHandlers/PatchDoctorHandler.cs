using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Enums;
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
        var doctorEntity = await _repository.Doctor.GetEntityAsync(request.Id, request.TrackChanges);

        if (doctorEntity is null)
            throw new EntityNotFoundException(request.Id);

        var doctorToPatch = _mapper.Map<DoctorForUpdateDto>(doctorEntity);

        request.PatchDoc.ApplyTo(doctorToPatch, (error) =>
        {
            throw new PatchRequestException($"Error applying patch: {error.ErrorMessage}");
        });

        _mapper.Map(doctorToPatch, doctorEntity);

        if (doctorEntity.ApplicationUser != null)
        {
            if (doctorToPatch.FirstName != null)
                doctorEntity.ApplicationUser.FirstName = doctorToPatch.FirstName;

            if (doctorToPatch.LastName != null)
                doctorEntity.ApplicationUser.LastName = doctorToPatch.LastName;

            if (doctorToPatch.CardId != null)
                doctorEntity.ApplicationUser.CardId = doctorToPatch.CardId;

            if (doctorToPatch.IsActive != null)
                doctorEntity.ApplicationUser.IsActive = doctorToPatch.IsActive;

            if (doctorToPatch.Birthdate != null)
                doctorEntity.ApplicationUser.Birthdate = doctorToPatch.Birthdate;

            if (doctorToPatch.Email != null)
                doctorEntity.ApplicationUser.Email = doctorToPatch.Email;

            if (doctorToPatch.Sex != null)
                doctorEntity.ApplicationUser.Sex = Enum.Parse<SexEnum>(doctorToPatch.Sex, true);

            if (doctorToPatch.PhoneNumber != null)
                doctorEntity.ApplicationUser.PhoneNumber = doctorToPatch.PhoneNumber;
        }

        await _repository.SaveAsync(cancellationToken);

        return (doctorToPatch, doctorEntity);
    }
}
