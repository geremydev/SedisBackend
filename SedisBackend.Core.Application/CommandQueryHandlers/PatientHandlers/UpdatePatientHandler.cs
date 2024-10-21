using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PatientCommandHandlers;

public sealed record UpdatePatientCommand(Guid Id, PatientForUpdateDto Patient, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePatientHandler : IRequestHandler<UpdatePatientCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePatientHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patientEntity = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Patient, patientEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
