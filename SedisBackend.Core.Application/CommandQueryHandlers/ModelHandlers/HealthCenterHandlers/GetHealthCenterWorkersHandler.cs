using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.DTO.Entities.Users.Assistants;
using SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;
using SedisBackend.Core.Domain.DTO.Entities.Users.LabTech;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.HealthCenterHandlers;

public record GetHealthCenterWorkersQuery(Guid Id) : IRequest<HealthCenterWorkersDto>;
public class GetHealthCenterWorkersHandler : IRequestHandler<GetHealthCenterWorkersQuery, HealthCenterWorkersDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetHealthCenterWorkersHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HealthCenterWorkersDto> Handle(GetHealthCenterWorkersQuery request, CancellationToken cancellationToken)
    {
        var result = new HealthCenterWorkersDto();
        var healthCenter = await _repository.HealthCenter.GetEntityAsync(request.Id, false);
        if (healthCenter != null)
        {
            result.Assistants = _mapper.Map<ICollection<Assistant>, ICollection<AssistantDto>>(_repository.Assistant.GetByHealthCenterId(request.Id));
            result.Doctors = _mapper.Map<ICollection<Doctor>, ICollection<DoctorDto>>(_repository.Doctor.GetByHealthCenterId(request.Id));
            result.LabTechs = _mapper.Map<ICollection<LabTech>, ICollection<LabTechDto>>(_repository.LabTech.GetByHealthCenterId(request.Id));
        }
        return result;
    }

}
