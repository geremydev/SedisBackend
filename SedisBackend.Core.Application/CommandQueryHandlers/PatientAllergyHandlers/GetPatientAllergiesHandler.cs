using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.AllergyHandlers;

public sealed record GetPatientAllergiesQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientAllergyDto>>;

internal sealed class GetPatientAllergiesHandler : IRequestHandler<GetPatientAllergiesQuery, IEnumerable<PatientAllergyDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientAllergiesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientAllergyDto>> Handle(GetPatientAllergiesQuery request, CancellationToken cancellationToken)
    {
        var Allergies = await _repository.PatientAllergy.GetAllEntitiesAsync(request.TrackChanges);
        var patientAllergies = Allergies.Where(e=> e.PatientId == request.PatientId && e.Status == true).ToList();
        if (patientAllergies is null || !patientAllergies.Any())
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<IEnumerable<PatientAllergyDto>>(patientAllergies);
        return patientAllergiesDot;
    }
}

