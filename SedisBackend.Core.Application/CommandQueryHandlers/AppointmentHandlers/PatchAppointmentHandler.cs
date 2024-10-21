using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AppointmentHandlers;

public sealed record PatchAppointmentCommand(Guid Id, bool TrackChanges, JsonPatchDocument<AppointmentForUpdateDto> PatchDoc)
    : IRequest<(AppointmentForUpdateDto AppointmentToPatch, Appointment AppointmentEntity)>;

internal sealed class PatchAppointmentHandler
    : IRequestHandler<PatchAppointmentCommand, (AppointmentForUpdateDto AppointmentToPatch, Appointment AppointmentEntity)>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PatchAppointmentHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(AppointmentForUpdateDto AppointmentToPatch, Appointment AppointmentEntity)> Handle(
        PatchAppointmentCommand request, CancellationToken cancellationToken)
    {
        var AppointmentEntity = await _repository.Appointment.GetEntityAsync(request.Id, request.TrackChanges);
        if (AppointmentEntity is null)
            throw new EntityNotFoundException(request.Id);

        var AppointmentToPatch = _mapper.Map<AppointmentForUpdateDto>(AppointmentEntity);
        request.PatchDoc.ApplyTo(AppointmentToPatch);

        _mapper.Map(AppointmentToPatch, AppointmentEntity);
        await _repository.SaveAsync(cancellationToken);

        return (AppointmentToPatch, AppointmentEntity);
    }
}
