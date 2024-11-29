using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record GetPatientLabTestQuery(Guid Id, bool TrackChanges) : IRequest<PatientLabTestPrescriptionDto>;

internal sealed class GetPatientLabTestPrescriptionHandler : IRequestHandler<GetPatientLabTestQuery, PatientLabTestPrescriptionDto>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientLabTestPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PatientLabTestPrescriptionDto> Handle(GetPatientLabTestQuery request, CancellationToken cancellationToken)
    {
        var patientLabTests = await _repository.PatientLabTestPrescription.GetEntityAsync(request.Id, request.TrackChanges);
        if (patientLabTests is null)
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<PatientLabTestPrescriptionDto>(patientLabTests);
        return patientAllergiesDot;
    }
}

