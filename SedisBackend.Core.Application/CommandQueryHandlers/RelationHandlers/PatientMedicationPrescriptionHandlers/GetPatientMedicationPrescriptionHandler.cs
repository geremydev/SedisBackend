using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record GetPatientMedicationsQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientMedicationPrescriptionDto>>;

internal sealed class GetPatientMedicationsPrescriptionHandler : IRequestHandler<GetPatientMedicationsQuery, IEnumerable<PatientMedicationPrescriptionDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientMedicationsPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientMedicationPrescriptionDto>> Handle(GetPatientMedicationsQuery request, CancellationToken cancellationToken)
    {
        var patientMedications = await _repository.PatientMedicationPrescriptionRepository.GetByPatient(request.PatientId, request.TrackChanges);
        if (patientMedications is null || !patientMedications.Any())
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<IEnumerable<PatientMedicationPrescriptionDto>>(patientMedications);
        return patientAllergiesDot;
    }
}

