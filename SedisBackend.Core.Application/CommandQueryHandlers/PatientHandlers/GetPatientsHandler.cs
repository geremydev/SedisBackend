using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.PatientHandlers;

public sealed record GetPatientsQuery(bool TrackChanges) : IRequest<IEnumerable<PatientDto>>;

internal sealed class GetPatientsHandler : IRequestHandler<GetPatientsQuery, IEnumerable<PatientDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        var Patients = await _repository.Patient.GetAllEntitiesAsync(request.TrackChanges);

        if (Patients is null || !Patients.Any())
            throw new EntitiesNotFoundException();

        var PatientsDto = _mapper.Map<IEnumerable<PatientDto>>(Patients);
        return PatientsDto;
    }
}
