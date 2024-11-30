using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalSpecialtyHandlers;

public sealed record CreateMedicalSpecialtyCommand(MedicalSpecialtyForCreationDto medicalSpecialty) : IRequest<MedicalSpecialtyDto>;

internal sealed class CreateMedicalSpecialtyHandler : IRequestHandler<CreateMedicalSpecialtyCommand, MedicalSpecialtyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicalSpecialtyDto> Handle(CreateMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var medicalSpecialtyEntity = _mapper.Map<MedicalSpecialty>(request.medicalSpecialty);
        _repository.MedicalSpecialty.CreateEntity(medicalSpecialtyEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<MedicalSpecialtyDto>(medicalSpecialtyEntity);
    }
}
