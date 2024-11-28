using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
using SedisBackend.Core.Domain.DTO.Entities.HealthCenterService;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.DoctorMedicalSpecialtyHandlers;

public sealed record GetAllHealthCentersMedicalSpecialtyQuery(Guid HealthCenterId, bool TrackChanges) : IRequest<IEnumerable<HealthCenterServiceDto>>;

internal sealed class GetAllHealthCenterServicesHandler : IRequestHandler<GetAllHealthCentersMedicalSpecialtyQuery, IEnumerable<HealthCenterServiceDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAllHealthCenterServicesHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HealthCenterServiceDto>> Handle(GetAllHealthCentersMedicalSpecialtyQuery request, CancellationToken cancellationToken)
    {
        var healthcenterService = await _repository.HealthCenterServices.GetByHealthCenter(request.HealthCenterId, request.TrackChanges);
        if (healthcenterService is null)
            throw new EntityNotFoundException(request.HealthCenterId);

        return _mapper.Map<ICollection<HealthCenterServiceDto>>(healthcenterService);
    }
}
