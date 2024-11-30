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
        _repository.PatientLabTestPrescription.CreateEntity(LabTestPrescriptionEntity);
        await _repository.SaveAsync(cancellationToken);
            

        return _mapper.Map<PatientLabTestPrescriptionDto>(LabTestPrescriptionEntity);
    }
}
