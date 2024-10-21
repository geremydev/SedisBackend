using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AppointmentCommandHandlers;

public sealed record CreateAppointmentCommand(AppointmentForCreationDto appointment) : IRequest<AppointmentDto>;

internal sealed class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateAppointmentHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointmentEntity = _mapper.Map<Appointment>(request.appointment);
        _repository.Appointment.CreateEntity(appointmentEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<AppointmentDto>(appointmentEntity);
    }
}
