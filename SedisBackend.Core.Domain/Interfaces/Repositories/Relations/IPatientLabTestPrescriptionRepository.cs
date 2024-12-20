﻿using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.Interfaces.Repositories.Relations;
public interface IPatientLabTestPrescriptionRepository : IGenericRepository<PatientLabTestPrescription>
{
    Task<IEnumerable<PatientLabTestPrescription>> GetByPatient(Guid patientId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByLabTestPrescription(Guid labtestPrescriptionId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByLabTech(Guid labtechId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByDoctor(Guid doctorId, bool trackChanges);
    Task<IEnumerable<PatientLabTestPrescription>> GetByHealthCenter(Guid healthCenterId, bool trackChanges);
}
