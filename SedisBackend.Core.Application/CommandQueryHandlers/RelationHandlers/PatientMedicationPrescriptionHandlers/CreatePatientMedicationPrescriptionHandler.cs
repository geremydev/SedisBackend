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
        PatientMedicationPrescription existingMedicationPrescription = new();
        try
        {
            existingMedicationPrescription = await _repository.PatientMedicationPrescriptionRepository.GetEntityAsync(request.patientMedicationPrescription.PatientId, request.patientMedicationPrescription.MedicationId, false);
            if (existingMedicationPrescription != null && existingMedicationPrescription.Status == true)
            {
                throw new Exception("This patient has already registered this MedicationPrescription");
            }
            else if (existingMedicationPrescription != null && existingMedicationPrescription.Status == false)
            {
                _mapper.Map(request.patientMedicationPrescription, existingMedicationPrescription);
                request.patientMedicationPrescription.Status = true;
                _repository.PatientMedicationPrescriptionRepository.UpdateEntity(existingMedicationPrescription);
                await _repository.SaveAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(KeyNotFoundException))
            {
                _repository.PatientMedicationPrescriptionRepository.CreateEntity(MedicationPrescriptionEntity);
                await _repository.SaveAsync(cancellationToken);
            }
            else
            {
                throw ex;
            }
        }

        return _mapper.Map<PatientMedicationPrescriptionDto>(MedicationPrescriptionEntity);
    }
}
