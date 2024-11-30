using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalConsultationHandlers;
public sealed record GetMedicalConsultationByPatientQuery(Guid patientId, bool TrackChanges) : IRequest<IEnumerable<MedicalConsultationDto>>;

internal sealed class GetMedicalConsultationByPatientHandler : IRequestHandler<GetMedicalConsultationByPatientQuery, IEnumerable<MedicalConsultationDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalConsultationByPatientHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalConsultationDto>> Handle(GetMedicalConsultationByPatientQuery request, CancellationToken cancellationToken)
    {
        var medicalConsultation = await _repository.MedicalConsultation.GetByPatient(request.patientId, request.TrackChanges);
        if (medicalConsultation is null)
            throw new EntityNotFoundException(request.patientId);
        return _mapper.Map<IEnumerable<MedicalConsultationDto>>(medicalConsultation);
    }
}
