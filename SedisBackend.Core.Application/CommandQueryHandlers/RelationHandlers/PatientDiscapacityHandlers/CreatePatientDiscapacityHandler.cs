using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientDiscapacity;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientDiscapacityHandlers;
public sealed record CreatePatientDiscapacityCommand(PatientDiscapacityForCreationDto patientDiscapacity) : IRequest<PatientDiscapacityDto>;

public class CreatePatientDiscapacityHandler : IRequestHandler<CreatePatientDiscapacityCommand, PatientDiscapacityDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePatientDiscapacityHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientDiscapacityDto> Handle(CreatePatientDiscapacityCommand request, CancellationToken cancellationToken)
    {
        var DiscapacityEntity = _mapper.Map<PatientDiscapacity>(request.patientDiscapacity);
        PatientDiscapacity existingDiscapacity = new();
        try
        {
            existingDiscapacity = await _repository.PatientDiscapacity.GetEntityAsync(request.patientDiscapacity.PatientId, request.patientDiscapacity.DiscapacityId, false);
            if (existingDiscapacity != null && existingDiscapacity.Status == true)
            {
                throw new Exception("This patient has already registered this Discapacity");
            }
            else if (existingDiscapacity != null && existingDiscapacity.Status == false)
            {
                _mapper.Map(request.patientDiscapacity, existingDiscapacity);
                request.patientDiscapacity.Status = true;
                _repository.PatientDiscapacity.UpdateEntity(existingDiscapacity);
                await _repository.SaveAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(KeyNotFoundException))
            {
                _repository.PatientDiscapacity.CreateEntity(DiscapacityEntity);
                await _repository.SaveAsync(cancellationToken);
            }
            else
            {
                throw ex;
            }
        }

        return _mapper.Map<PatientDiscapacityDto>(DiscapacityEntity);
    }
}
