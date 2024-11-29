using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record GetPatientActiveAppointmentQuery(Guid PatientId, bool TrackChanges) : IRequest<ICollection<AppointmentDto>>;

internal sealed class GetPatientActiveAppointmentHandler : IRequestHandler<GetPatientActiveAppointmentQuery, ICollection<AppointmentDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientActiveAppointmentHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<AppointmentDto>> Handle(GetPatientActiveAppointmentQuery request, CancellationToken cancellationToken)
    {
        var patientAppointments = _repository.Appointment.GetAppointmentsByPatientAsync(request.PatientId, request.TrackChanges).ToList();

        if (patientAppointments is null /*agregar validación de si es 0*/)
            throw new EntityNotFoundException(request.PatientId);
        patientAppointments = patientAppointments.Where(e => e.Status == "Completed").ToList();
        return _mapper.Map<ICollection<AppointmentDto>>(patientAppointments);
    }
}

