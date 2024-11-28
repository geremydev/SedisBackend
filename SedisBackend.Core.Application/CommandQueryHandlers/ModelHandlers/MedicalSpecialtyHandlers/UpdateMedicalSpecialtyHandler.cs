using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalSpecialtyHandlers;

public sealed record UpdateMedicalSpecialtyCommand(Guid Id, MedicalSpecialtyForUpdateDto MedicalSpecialty, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateMedicalSpecialtyHandler : IRequestHandler<UpdateMedicalSpecialtyCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var medicalSpecialtyEntity = await _repository.MedicalSpecialty.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalSpecialtyEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.MedicalSpecialty, medicalSpecialtyEntity);
        _repository.MedicalSpecialty.UpdateEntity(medicalSpecialtyEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
