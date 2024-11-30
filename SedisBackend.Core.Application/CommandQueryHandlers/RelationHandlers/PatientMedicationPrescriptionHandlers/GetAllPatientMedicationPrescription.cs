using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record GetAllPatientMedicationsPresctiptionQuery(bool TrackChanges) : IRequest<IEnumerable<PatientMedicationPrescriptionDto>>;

internal sealed class GetAllPatientMedicationsPresctiptionHandler : IRequestHandler<GetAllPatientMedicationsPresctiptionQuery, IEnumerable<PatientMedicationPrescriptionDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAllPatientMedicationsPresctiptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientMedicationPrescriptionDto>> Handle(GetAllPatientMedicationsPresctiptionQuery request, CancellationToken cancellationToken)
    {
        var patientMedications = await _repository.PatientMedicationPrescription.GetAllEntitiesAsync(request.TrackChanges);
        if (patientMedications is null || !patientMedications.Any())
            throw new EntitiesNotFoundException();

        var patientMedicationDto = _mapper.Map<IEnumerable<PatientMedicationPrescriptionDto>>(patientMedications);
        return patientMedicationDto;
    }
}

