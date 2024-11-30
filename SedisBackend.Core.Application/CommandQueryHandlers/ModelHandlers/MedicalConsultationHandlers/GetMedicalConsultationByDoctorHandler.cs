using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;
public sealed record GetMedicalConsultationByDoctorQuery(Guid doctorId, bool TrackChanges) : IRequest<IEnumerable<MedicalConsultationDto>>;

internal sealed class GetMedicalConsultationByDoctorHandler : IRequestHandler<GetMedicalConsultationByDoctorQuery, IEnumerable<MedicalConsultationDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalConsultationByDoctorHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MedicalConsultationDto>> Handle(GetMedicalConsultationByDoctorQuery request, CancellationToken cancellationToken)
    {
        var medicalConsultation = await _repository.MedicalConsultation.GetByDoctor(request.doctorId, request.TrackChanges);
        if (medicalConsultation is null)
            throw new EntityNotFoundException(request.doctorId);
        return _mapper.Map<IEnumerable<MedicalConsultationDto>>(medicalConsultation);
    }
}
