using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalConsultationHandlers;

public sealed record CreateMedicalConsultationCommand(MedicalConsultationForCreationDto medicalConsultation) : IRequest<MedicalConsultationDto>;

internal sealed class CreateMedicalConsultationHandler : IRequestHandler<CreateMedicalConsultationCommand, MedicalConsultationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateMedicalConsultationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicalConsultationDto> Handle(CreateMedicalConsultationCommand request, CancellationToken cancellationToken)
    {
        var clinicalHistoryEntity = _mapper.Map<MedicalConsultation>(request.medicalConsultation);
        _repository.MedicalConsultation.CreateEntity(clinicalHistoryEntity);
        await _repository.SaveAsync(cancellationToken);
        return _mapper.Map<MedicalConsultationDto>(clinicalHistoryEntity);
    }
}
