using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Users.Patients;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.UserHandlers.PatientHandlers;

public sealed record GetPatientQuery(Guid Id, bool TrackChanges) : IRequest<PatientDto>;

internal sealed class GetPatientHandler : IRequestHandler<GetPatientQuery, PatientDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientDto> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
        var patient = await _repository.Patient.GetEntityAsync(request.Id, request.TrackChanges);
        if (patient is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<PatientDto>(patient);
    }
}
