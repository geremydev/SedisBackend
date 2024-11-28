using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.ClinicalHistoryHandlers;

public sealed record GetMedicalConsultationsQuery(bool TrackChanges) : IRequest<IEnumerable<MedicalConsultationDto>>;

public sealed class GetMedicalConsultationsHandler : IRequestHandler<GetMedicalConsultationsQuery, IEnumerable<MedicalConsultationDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalConsultationsHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalConsultationDto>> Handle(GetMedicalConsultationsQuery request, CancellationToken cancellationToken)
    {
        var medicalConsultations = await _repository.MedicalConsultation.GetAllEntitiesAsync(request.TrackChanges);

        if (medicalConsultations is null || !medicalConsultations.Any())
            throw new EntitiesNotFoundException();

        var medicalConsultationsDto = _mapper.Map<IEnumerable<MedicalConsultationDto>>(medicalConsultations);
        return medicalConsultationsDto;
    }
}
