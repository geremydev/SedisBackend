using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AppointmentCommandHandlers;

public sealed record GetAppointmentQuery(Guid Id, bool TrackChanges) : IRequest<AppointmentDto>;

internal sealed class GetAppointmentHandler : IRequestHandler<GetAppointmentQuery, AppointmentDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAppointmentHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AppointmentDto> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointment = await _repository.Appointment.GetEntityAsync(request.Id, request.TrackChanges);
        if (appointment is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<AppointmentDto>(appointment);
    }
}
