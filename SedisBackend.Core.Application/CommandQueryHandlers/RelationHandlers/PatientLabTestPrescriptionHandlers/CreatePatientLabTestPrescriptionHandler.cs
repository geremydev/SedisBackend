using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientLabTestPrescriptionHandlers;
public sealed record CreatePatientLabTestPrescriptionCommand(PatientLabTestPrescriptionForCreationDto patientLabTestPrescription) : IRequest<PatientLabTestPrescriptionDto>;

public class CreatePatientLabTestPrescriptionHandler : IRequestHandler<CreatePatientLabTestPrescriptionCommand, PatientLabTestPrescriptionDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientLabTestPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientLabTestPrescriptionDto> Handle(CreatePatientLabTestPrescriptionCommand request, CancellationToken cancellationToken)
    {
        var LabTestPrescriptionEntity = _mapper.Map<PatientLabTestPrescription>(request.patientLabTestPrescription);
        PatientLabTestPrescription existingLabTestPrescription = new();
        try
        {
            existingLabTestPrescription = await _repository.PatientLabTestPrescription.GetEntityAsync(request.patientLabTestPrescription.PatientId, request.patientLabTestPrescription.LabTestId, false);
            if (existingLabTestPrescription != null && existingLabTestPrescription.Status == "Activo")
            {
                throw new Exception("This patient has already registered this LabTestPrescription");
            }
            else if (existingLabTestPrescription != null && existingLabTestPrescription.Status == "Inactivo")
            {
                _mapper.Map(request.patientLabTestPrescription, existingLabTestPrescription);
                request.patientLabTestPrescription.Status = "Activo";
                _repository.PatientLabTestPrescription.UpdateEntity(existingLabTestPrescription);
                await _repository.SaveAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(KeyNotFoundException))
            {
                _repository.PatientLabTestPrescription.CreateEntity(LabTestPrescriptionEntity);
                await _repository.SaveAsync(cancellationToken);
            }
            else
            {
                throw ex;
            }
        }

        return _mapper.Map<PatientLabTestPrescriptionDto>(LabTestPrescriptionEntity);
    }
}
