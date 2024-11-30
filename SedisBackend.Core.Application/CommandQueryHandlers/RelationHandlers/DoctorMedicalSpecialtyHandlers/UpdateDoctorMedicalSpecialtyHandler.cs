using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.DoctorMedicalSpecialtyHandlers;

public sealed record UpdateDoctorMedicalSpecialtyCommand(Guid DoctorId, Guid MedicalSpecialtyId, DoctorMedicalSpecialtyForUpdateDto DoctorMedicalSpecialty, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateHealthCenterServiceHandler : IRequestHandler<UpdateDoctorMedicalSpecialtyCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateHealthCenterServiceHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateDoctorMedicalSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var DoctorMedicalSpecialtyEntity = await _repository.DoctorMedicalSpecialty.GetEntityAsync(request.DoctorId, request.MedicalSpecialtyId, request.TrackChanges);
        if (DoctorMedicalSpecialtyEntity is null)
            throw new EntityNotFoundException(request.MedicalSpecialtyId);

        _mapper.Map(request.DoctorMedicalSpecialty, DoctorMedicalSpecialtyEntity);
        _repository.DoctorMedicalSpecialty.UpdateEntity(DoctorMedicalSpecialtyEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
