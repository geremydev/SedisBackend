using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PatientCommandHandlers;

public sealed record CreatePatientCommand(PatientForCreationDto patient) : IRequest<PatientDto>;

internal sealed class CreatePatientHandler : IRequestHandler<CreatePatientCommand, PatientDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patientEntity = _mapper.Map<Patient>(request.patient);
        _repository.Patient.CreateEntity(patientEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<PatientDto>(patientEntity);
    }
}
