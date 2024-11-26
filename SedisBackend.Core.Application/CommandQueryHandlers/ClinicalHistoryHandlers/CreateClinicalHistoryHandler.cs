using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Interfaces.Repositories;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Application.CommandHandlers.ClinicalHistoryCommandHandlers;

public sealed record CreateClinicalHistoryCommand(ClinicalHistoryForCreationDto clinicalHistory) : IRequest<ClinicalHistoryDto>;

internal sealed class CreateClinicalHistoryHandler : IRequestHandler<CreateClinicalHistoryCommand, ClinicalHistoryDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CreateClinicalHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClinicalHistoryDto> Handle(CreateClinicalHistoryCommand request, CancellationToken cancellationToken)
    {
        var clinicalHistoryEntity = _mapper.Map<MedicalConsultation>(request.clinicalHistory);
        _repository.ClinicalHistory.CreateEntity(clinicalHistoryEntity);
        await _repository.SaveAsync(cancellationToken);

        return _mapper.Map<ClinicalHistoryDto>(clinicalHistoryEntity);
    }
}
