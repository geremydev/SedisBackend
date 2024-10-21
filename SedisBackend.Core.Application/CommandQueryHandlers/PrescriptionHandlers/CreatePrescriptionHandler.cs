using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Prescriptions;
using SedisBackend.Core.Domain.Entities.Models;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandHandlers.PrescriptionCommandHandlers;

public sealed record CreatePrescriptionCommand(PrescriptionForCreationDto prescription) : IRequest<PrescriptionDto>;

internal sealed class CreatePrescriptionHandler : IRequestHandler<CreatePrescriptionCommand, PrescriptionDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreatePrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PrescriptionDto> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescriptionEntity = _mapper.Map<Prescription>(request.prescription);
        _repository.Prescription.CreateEntity(prescriptionEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<PrescriptionDto>(prescriptionEntity);
    }
}
