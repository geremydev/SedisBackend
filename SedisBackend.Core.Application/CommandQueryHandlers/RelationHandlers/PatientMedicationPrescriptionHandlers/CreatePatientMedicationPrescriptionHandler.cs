using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientMedicationPrescription;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientMedicationPrescriptionHandlers;
public sealed record CreatePatientMedicationPrescriptionCommand(PatientMedicationPrescriptionForCreationDto patientMedicationPrescription) : IRequest<PatientMedicationPrescriptionDto>;

public class CreatePatientMedicationPrescriptionHandler : IRequestHandler<CreatePatientMedicationPrescriptionCommand, PatientMedicationPrescriptionDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientMedicationPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientMedicationPrescriptionDto> Handle(CreatePatientMedicationPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var MedicationPrescriptionEntity = _mapper.Map<PatientMedicationPrescription>(request.patientMedicationPrescription);
        _repository.PatientMedicationPrescription.CreateEntity(MedicationPrescriptionEntity);
        await _repository.SaveAsync(cancellationToken);
            
        return _mapper.Map<PatientMedicationPrescriptionDto>(MedicationPrescriptionEntity);
    }
}
