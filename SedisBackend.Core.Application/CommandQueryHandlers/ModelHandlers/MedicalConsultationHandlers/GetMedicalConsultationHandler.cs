using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalConsultationHandlers;

public sealed record GetMedicalConsultationQuery(Guid Id, bool TrackChanges) : IRequest<MedicalConsultationDto>;

internal sealed class GetMedicalConsultationHandler : IRequestHandler<GetMedicalConsultationQuery, MedicalConsultationDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalConsultationHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicalConsultationDto> Handle(GetMedicalConsultationQuery request, CancellationToken cancellationToken)
    {
        var medicalConsultation = await _repository.MedicalConsultation.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalConsultation is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<MedicalConsultationDto>(medicalConsultation);
    }
}
