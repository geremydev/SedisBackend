using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.ClinicalHistoryHandlers;

public sealed record GetClinicalHistoryQuery(Guid Id, bool TrackChanges) : IRequest<MedicalConsultationDto>;

internal sealed class GetClinicalHistoryHandler : IRequestHandler<GetClinicalHistoryQuery, MedicalConsultationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetClinicalHistoryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicalConsultationDto> Handle(GetClinicalHistoryQuery request, CancellationToken cancellationToken)
    {
        var clinicalHistory = await _repository.MedicalConsultation.GetEntityAsync(request.Id, request.TrackChanges);
        if (clinicalHistory is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<MedicalConsultationDto>(clinicalHistory);
    }
}
