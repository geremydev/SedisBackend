using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record GetDoctorPendingAppointmentsQuery(Guid DoctorId, bool TrackChanges) : IRequest<ICollection<AppointmentDto>>;

internal sealed class GetDoctorPendingAppointmentsHandler : IRequestHandler<GetDoctorPendingAppointmentsQuery, ICollection<AppointmentDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDoctorPendingAppointmentsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<AppointmentDto>> Handle(GetDoctorPendingAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var doctorAppointments = await _repository.Appointment.GetAppointmentsByDoctor(request.DoctorId, request.TrackChanges);

        if (doctorAppointments is null)
            throw new EntityNotFoundException(request.DoctorId);
        doctorAppointments = doctorAppointments.Where(e => e.Status == "Pending").ToList();
        return _mapper.Map<ICollection<AppointmentDto>>(doctorAppointments);
    }
}
