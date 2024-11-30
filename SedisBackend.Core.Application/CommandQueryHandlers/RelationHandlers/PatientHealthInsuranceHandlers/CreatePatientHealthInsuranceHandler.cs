using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientHealthInsurance;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;
public sealed record CreatePatientHealthInsuranceCommand(PatientHealthInsuranceForCreationDto patientHealthInsurance) : IRequest<PatientHealthInsuranceDto>;

public class CreatePatientHealthInsuranceHandler : IRequestHandler<CreatePatientHealthInsuranceCommand, PatientHealthInsuranceDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientHealthInsuranceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientHealthInsuranceDto> Handle(CreatePatientHealthInsuranceCommand request, CancellationToken cancellationToken)
    {
        var HealthInsuranceEntity = _mapper.Map<PatientHealthInsurance>(request.patientHealthInsurance);
        PatientHealthInsurance existingHealthInsurance = new();
        try
        {
            existingHealthInsurance = await _repository.PatientHealthInsurance.GetEntityAsync(request.patientHealthInsurance.PatientId, request.patientHealthInsurance.HealthInsuranceId, false);
            if (existingHealthInsurance != null && existingHealthInsurance.Status == true)
            {
                throw new Exception("This patient has already registered this HealthInsurance");
            }
            else if (existingHealthInsurance != null && existingHealthInsurance.Status == false)
            {
                _mapper.Map(request.patientHealthInsurance, existingHealthInsurance);
                request.patientHealthInsurance.Status = true    ;
                _repository.PatientHealthInsurance.UpdateEntity(existingHealthInsurance);
                await _repository.SaveAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(KeyNotFoundException))
            {
                _repository.PatientHealthInsurance.CreateEntity(HealthInsuranceEntity);
                await _repository.SaveAsync(cancellationToken);
            }
            else
            {
                throw ex;
            }
        }

        return _mapper.Map<PatientHealthInsuranceDto>(HealthInsuranceEntity);
    }
}
