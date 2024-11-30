using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientMedicationPrescriptionHandlers;
public sealed record GetPatientActiveMedicationsQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientMedicationPrescriptionDto>>;

internal sealed class GetPatientActiveMedicationsHandler : IRequestHandler<GetPatientActiveMedicationsQuery, IEnumerable<PatientMedicationPrescriptionDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientActiveMedicationsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientMedicationPrescriptionDto>> Handle(GetPatientActiveMedicationsQuery request, CancellationToken cancellationToken)
    {
        var patientMedications = await _repository.PatientMedicationPrescription.GetByPatient(request.PatientId, request.TrackChanges);
        if (patientMedications is null || !patientMedications.Any())
            throw new EntitiesNotFoundException();
        var patientMedicationDto = _mapper.Map<IEnumerable<PatientMedicationPrescriptionDto>>(patientMedications);
        return patientMedicationDto;
    }
}
