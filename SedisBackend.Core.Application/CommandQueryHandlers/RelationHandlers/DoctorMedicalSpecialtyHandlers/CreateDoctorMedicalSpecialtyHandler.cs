using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Entities.Relations;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.MedicationCoverageHandlers;

public sealed record CreateDoctorMedicalSpecialtyCommand(DoctorMedicalSpecialtyForCreationDto doctorMedicalSpecialty) : IRequest<DoctorMedicalSpecialtyDto>;

internal sealed class CreateHealthCenterServiceHandler : IRequestHandler<CreateDoctorMedicalSpecialtyCommand, DoctorMedicalSpecialtyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateHealthCenterServiceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoctorMedicalSpecialtyDto> Handle(CreateDoctorMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var doctorMedicalSpecialty = _mapper.Map<DoctorMedicalSpecialty>(request.doctorMedicalSpecialty);
        _repository.DoctorMedicalSpecialty.CreateEntity(doctorMedicalSpecialty);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<DoctorMedicalSpecialtyDto>(doctorMedicalSpecialty);
    }
}
