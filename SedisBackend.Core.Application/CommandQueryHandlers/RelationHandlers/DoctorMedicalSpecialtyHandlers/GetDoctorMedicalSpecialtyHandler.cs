using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.DoctorMedicalSpecialty;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.DoctorMedicalSpecialtyHandlers;

public sealed record GetDoctorMedicalSpecialtyQuery(Guid DoctorId, Guid SpecialtyId, bool TrackChanges) : IRequest<DoctorMedicalSpecialtyDto>;

internal sealed class GetDoctorMedicalSpecialtyHandler : IRequestHandler<GetDoctorMedicalSpecialtyQuery, DoctorMedicalSpecialtyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetDoctorMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DoctorMedicalSpecialtyDto> Handle(GetDoctorMedicalSpecialtyQuery request, CancellationToken cancellationToken)
    {
        var DoctorMedicalSpecialty = await _repository.DoctorMedicalSpecialty.GetEntityAsync(request.DoctorId, request.SpecialtyId, request.TrackChanges);
        if (DoctorMedicalSpecialty is null)
            throw new EntityNotFoundException(request.SpecialtyId);

        return _mapper.Map<DoctorMedicalSpecialtyDto>(DoctorMedicalSpecialty);
    }
}
