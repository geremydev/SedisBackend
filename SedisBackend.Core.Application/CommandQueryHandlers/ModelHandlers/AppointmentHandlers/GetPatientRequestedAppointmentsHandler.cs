using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record GetPatientRequestedAppointmentsQuery(Guid PatientId, bool TrackChanges) : IRequest<ICollection<AppointmentDto>>;

internal sealed class GetPatientRequestedAppointmentsHandler : IRequestHandler<GetPatientRequestedAppointmentsQuery, ICollection<AppointmentDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientRequestedAppointmentsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ICollection<AppointmentDto>> Handle(GetPatientRequestedAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var patientAppointments = await _repository.Appointment.GetAppointmentsByPatientAsync(request.PatientId, request.TrackChanges);

        if (patientAppointments is null /*agregar validación de si es 0*/)
            throw new EntityNotFoundException(request.PatientId);
        patientAppointments = patientAppointments.Where(e => e.Status == "Requested").ToList();
        return _mapper.Map<ICollection<AppointmentDto>>(patientAppointments);
    }
}
