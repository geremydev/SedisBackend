using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.ClinicalHistoryHandlers;

public sealed record UpdateMedicalConsultationCommand(Guid Id, MedicalConsultationForUpdateDto MedicalConsultation, bool TrackChanges) : IRequest<Unit>;

internal sealed class UpdateMedicalConsultationHandler : IRequestHandler<UpdateMedicalConsultationCommand, Unit>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public UpdateMedicalConsultationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        var medicalConsultationEntity = await _repository.MedicalConsultation.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalConsultationEntity is null)
            throw new EntityNotFoundException(request.Id);

        _mapper.Map(request.MedicalConsultation, medicalConsultationEntity);
        _repository.MedicalConsultation.UpdateEntity(medicalConsultationEntity);
        await _repository.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}
