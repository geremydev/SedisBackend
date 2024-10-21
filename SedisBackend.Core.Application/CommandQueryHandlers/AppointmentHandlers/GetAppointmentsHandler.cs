using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AppointmentHandlers;

public sealed record GetAppointmentsQuery(bool TrackChanges) : IRequest<IEnumerable<AppointmentDto>>;

internal sealed class GetAppointmentsHandler : IRequestHandler<GetAppointmentsQuery, IEnumerable<AppointmentDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAppointmentsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AppointmentDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var Appointments = await _repository.Appointment.GetAllEntitiesAsync(request.TrackChanges);

        if (Appointments is null || !Appointments.Any())
            throw new EntitiesNotFoundException();

        var AppointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(Appointments);
        return AppointmentsDto;
    }
}
