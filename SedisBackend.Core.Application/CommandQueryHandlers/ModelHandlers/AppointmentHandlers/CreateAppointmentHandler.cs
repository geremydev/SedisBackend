using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.AppointmentHandlers;

public sealed record CreateAppointmentCommand(AppointmentForCreationDto Appointment) : IRequest<AppointmentDto>;

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
        var clinicalHistoryEntity = _mapper.Map<Appointment>(request.Appointment);
        _repository.Appointment.CreateEntity(clinicalHistoryEntity);
        await _repository.SaveAsync(cancellationToken);
        return _mapper.Map<AppointmentDto>(clinicalHistoryEntity);
    }
}
