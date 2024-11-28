using AutoMapper;
using MediatR;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Allergies;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.PatientIllness;
using SedisBackend.Core.Domain.DTO.Entities.PatientLabTestPrescription;
using SedisBackend.Core.Domain.Exceptions;
using SedisBackend.Core.Domain.Interfaces.Repositories;

namespace SedisBackend.Core.Application.CommandQueryHandlers.RelationHandlers.PatientIllnessHandlers;

public sealed record GetPatientLabTestsQuery(Guid PatientId, bool TrackChanges) : IRequest<IEnumerable<PatientLabTestPrescriptionDto>>;

internal sealed class GetPatientLabTestsPrescriptionHandler : IRequestHandler<GetPatientLabTestsQuery, IEnumerable<PatientLabTestPrescriptionDto>>
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public GetPatientLabTestsPrescriptionHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientLabTestPrescriptionDto>> Handle(GetPatientLabTestsQuery request, CancellationToken cancellationToken)
    {
        var patientLabTests = await _repository.PatientIllness.GetByPatient(request.PatientId, request.TrackChanges);
        if (patientLabTests is null || !patientLabTests.Any())
            throw new EntitiesNotFoundException();

        var patientAllergiesDot = _mapper.Map<IEnumerable<PatientLabTestPrescriptionDto>>(patientLabTests);
        return patientAllergiesDot;
    }
}

