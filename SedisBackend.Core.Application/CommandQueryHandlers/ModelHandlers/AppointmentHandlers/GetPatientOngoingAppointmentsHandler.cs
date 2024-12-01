using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record GetPatientOngoingAppointmentsQuery(Guid PatientId, bool TrackChanges) : IRequest<ICollection<AppointmentDto>>;

internal sealed class GetPatientOngoingAppointmentsHandler : IRequestHandler<GetPatientOngoingAppointmentsQuery, ICollection<AppointmentDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientOngoingAppointmentsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<AppointmentDto>> Handle(GetPatientOngoingAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var patientAppointments = await _repository.Appointment.GetAppointmentsByPatientAsync(request.PatientId, request.TrackChanges);

        if (patientAppointments is null)
            throw new EntityNotFoundException(request.PatientId);
        patientAppointments = patientAppointments.Where(e => e.Status == "Ongoing").ToList();
        return _mapper.Map<ICollection<AppointmentDto>>(patientAppointments);
    }
}
