using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Products.Medication;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.MedicationCommandHandlers;

public sealed record UpdateMedicationCommand(Guid Id, MedicationForUpdateDto Medication, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateMedicationHandler : IRequestHandler<UpdateMedicationCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateMedicationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
    {
        var medicationEntity = await _repository.Medication.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicationEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Medication, medicationEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
