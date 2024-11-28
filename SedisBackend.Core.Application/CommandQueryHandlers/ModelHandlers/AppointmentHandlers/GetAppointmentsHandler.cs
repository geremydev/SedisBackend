using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.ClinicalHistoryHandlers;

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
        var appointments = await _repository.Appointment.GetAllEntitiesAsync(request.TrackChanges);

        if (appointments is null || !appointments.Any())
            throw new EntitiesNotFoundException();

        var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
        return appointmentsDto;
    }
}
