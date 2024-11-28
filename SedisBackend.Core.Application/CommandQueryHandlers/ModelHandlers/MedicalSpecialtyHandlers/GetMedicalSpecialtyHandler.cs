using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.ModelHandlers.MedicalSpecialtyHandlers;

public sealed record GetMedicalSpecialtyQuery(Guid Id, bool TrackChanges) : IRequest<MedicalSpecialtyDto>;

internal sealed class GetMedicalSpecialtyHandler : IRequestHandler<GetMedicalSpecialtyQuery, MedicalSpecialtyDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetMedicalSpecialtyHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MedicalSpecialtyDto> Handle(GetMedicalSpecialtyQuery request, CancellationToken cancellationToken)
    {
        var medicalSpecialty = await _repository.MedicalSpecialty.GetEntityAsync(request.Id, request.TrackChanges);
        if (medicalSpecialty is null)
            throw new EntityNotFoundException(request.Id);

        return _mapper.Map<MedicalSpecialtyDto>(medicalSpecialty);
    }
}
