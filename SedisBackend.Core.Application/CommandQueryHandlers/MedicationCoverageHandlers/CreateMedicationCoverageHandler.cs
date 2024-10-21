using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Insurance.MedicationCoverageDTO;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_Insurance;

namespace SedisBackend.Core.Application.CommandHandlers.MedicationCoverageCommandHandlers;

public sealed record CreateMedicationCoverageCommand(MedicationCoverageForCreationDto medicationCoverage) : IRequest<MedicationCoverageDto>;

internal sealed class CreateMedicationCoverageHandler : IRequestHandler<CreateMedicationCoverageCommand, MedicationCoverageDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateMedicationCoverageHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicationCoverageDto> Handle(CreateMedicationCoverageCommand request, CancellationToken cancellationToken)
    {
        var medicationCoverageEntity = _mapper.Map<MedicationCoverage>(request.medicationCoverage);
        _repository.MedicationCoverage.CreateEntity(medicationCoverageEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<MedicationCoverageDto>(medicationCoverageEntity);
    }
}
