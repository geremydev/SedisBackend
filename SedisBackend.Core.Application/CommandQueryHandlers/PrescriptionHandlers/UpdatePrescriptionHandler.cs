using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Prescriptions;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PrescriptionCommandHandlers;

public sealed record UpdatePrescriptionCommand(Guid Id, PrescriptionForUpdateDto Prescription, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdatePrescriptionHandler : IRequestHandler<UpdatePrescriptionCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdatePrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescriptionEntity = await _repository.Prescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (prescriptionEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.Prescription, prescriptionEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
