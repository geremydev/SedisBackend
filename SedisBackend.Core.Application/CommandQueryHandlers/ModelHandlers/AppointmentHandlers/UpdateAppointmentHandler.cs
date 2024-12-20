using AutoMapper;
using MediatR;
using SedisBackend.Core.Application.Events;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record UpdateAppointmentCommand(Guid Id, AppointmentForUpdateDto Appointment, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateAppointmentHandler : IRequestHandler<UpdateAppointmentCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateAppointmentHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var AppointmentEntity = await _repository.Appointment.GetEntityAsync(request.Id, request.TrackChanges);
        if (AppointmentEntity is null)
            throw new EntityNotFoundException(request.Id);

        var entity = _mapper.Map(request.Appointment, AppointmentEntity);
        _repository.Appointment.UpdateEntity(entity);
        await _repository.SaveAsync(cancellationToken);

        var appointmentApprovedEvent = _mapper.Map<AppointmentApprovedEvent>(AppointmentEntity);

        return Unit.Value;
    }
}
