using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.MedicationCommandHandlers;

public sealed record CreateMedicationCommand(MedicationForCreationDto medication) : IRequest<MedicationDto>;

internal sealed class CreateMedicationHandler : IRequestHandler<CreateMedicationCommand, MedicationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateMedicationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicationDto> Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
    {
        var medicationEntity = _mapper.Map<Medication>(request.medication);
        _repository.Medication.CreateEntity(medicationEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<MedicationDto>(medicationEntity);
    }
}
