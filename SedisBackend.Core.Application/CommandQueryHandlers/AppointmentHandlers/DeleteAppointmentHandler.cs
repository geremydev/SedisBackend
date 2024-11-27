using MediatR;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.AppointmentCommandHandlers;

public record DeleteAppointmentCommand(Guid Id, bool TrackChanges) : IRequest;

internal sealed class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand>
{
    private readonly IRepositoryManager _repository;

    public DeleteAppointmentHandler(IRepositoryManager repository) => _repository = repository;

    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _repository.Appointment.GetEntityAsync(request.Id, request.TrackChanges);
        if (appointment is null)
            throw new EntityNotFoundException(request.Id);

        appointment.Status = "Deleted";
        await _repository.SaveAsync(cancellationToken);
    }
}
