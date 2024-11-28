using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.ClinicalHistoryHandlers;

public sealed record GetMedicalConsultationQuery(bool TrackChanges) : IRequest<IEnumerable<MedicalConsultationDto>>;

internal sealed class GetMedicalConsultationHandler : IRequestHandler<GetMedicalConsultationQuery, IEnumerable<MedicalConsultationDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalConsultationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalConsultationDto>> Handle(GetMedicalConsultationQuery request, CancellationToken cancellationToken)
    {
        var ClinicalHistorys = await _repository.MedicalConsultation.GetAllEntitiesAsync(request.TrackChanges);

        if (ClinicalHistorys is null || !ClinicalHistorys.Any())
            throw new EntitiesNotFoundException();

        var ClinicalHistorysDto = _mapper.Map<IEnumerable<MedicalConsultationDto>>(ClinicalHistorys);
        return ClinicalHistorysDto;
    }
}
