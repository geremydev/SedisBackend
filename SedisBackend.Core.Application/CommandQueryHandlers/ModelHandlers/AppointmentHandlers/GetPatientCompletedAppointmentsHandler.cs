using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;
public sealed record GetPatientCompletedAppointmentsQuery(Guid patientId, bool TrackChanges) : IRequest<ICollection<AppointmentDto>>;

internal sealed class GetPatientCompletedAppointmentsHandler : IRequestHandler<GetPatientCompletedAppointmentsQuery, ICollection<AppointmentDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientCompletedAppointmentsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<AppointmentDto>> Handle(GetPatientCompletedAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var patientAppointments = await _repository.Appointment.GetAppointmentsByPatientAsync(request.patientId, request.TrackChanges);

        if (patientAppointments is null)
            throw new EntityNotFoundException(request.patientId);
        patientAppointments = patientAppointments.Where(e => e.Status == "Completed").ToList();
        return _mapper.Map<ICollection<AppointmentDto>>(patientAppointments);
    }
}
