using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.DoctorMedicalSpecialtyHandlers;

public sealed record GetAllDoctorsMedicalSpecialtyQuery(Guid DoctorId, bool TrackChanges) : IRequest<DoctorMedicalSpecialtyDto>;

internal sealed class GetAllDoctorsMedicalSpecialtyHandler : IRequestHandler<GetDoctorMedicalSpecialtyQuery, DoctorMedicalSpecialtyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetAllDoctorsMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoctorMedicalSpecialtyDto> Handle(GetDoctorMedicalSpecialtyQuery request, CancellationToken cancellationToken)
    {
        var doctorMedicalSpecialty = await _repository.DoctorMedicalSpecialty.GetByDoctor(request.DoctorId, request.TrackChanges);
        if (doctorMedicalSpecialty is null)
            throw new EntityNotFoundException(request.SpecialtyId);

        return _mapper.Map<DoctorMedicalSpecialtyDto>(doctorMedicalSpecialty);
    }
}
