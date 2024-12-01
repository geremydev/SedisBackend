using AutoMapper;
using MassTransit;
using MediatR;
using SedisBackend.Core.Application.Events;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record CreateAppointmentCommand(AppointmentForCreationDto Appointment) : IRequest<AppointmentDto>;

internal sealed class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IMapper _mapper;

    public CreateAppointmentHandler(IRepositoryManager repository, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _repository = repository;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<AppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.Doctor.GetEntityAsync(request.Appointment.DoctorId, false);

        if (doctor == null)
            throw new EntityNotFoundException(request.Appointment.DoctorId);

        var clinicalHistoryEntity = _mapper.Map<Appointment>(request.Appointment);
        clinicalHistoryEntity.HealthCenterId = doctor.CurrentlyWorkingHealthCenterId;
        clinicalHistoryEntity.Status = "Requested"; // La cita está solicitada, si se aprueba está pendiente hasta que se de con el doctor.
        _repository.Appointment.CreateEntity(clinicalHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        // HealthCenterId

        // El usuario va a crear la solicitud de cita, solo que la guardaremos como Solicitada de aprobacion hasta que el asistente apruebe.
        // No es ideal pero no hay tiempo.
        var createdAppointment = _mapper.Map<AppointmentCreatedEvent>(clinicalHistoryEntity);
        await _publishEndpoint.Publish(createdAppointment);

        return _mapper.Map<AppointmentDto>(clinicalHistoryEntity);
    }
}
