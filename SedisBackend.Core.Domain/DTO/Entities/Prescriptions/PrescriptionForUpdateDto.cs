﻿using SedisBackend.Core.Domain.Entities.Relations;

namespace SedisBackend.Core.Domain.DTO.Entities.Prescriptions;

public record PrescriptionForUpdateDto
{
    public Guid ClinicalHistoryId { get; set; }
    public ICollection<MedicationPrescription>? PrescribedMedications { get; set; }
    public ICollection<AppointmentPrescription>? PrescribedAppointments { get; set; }
    public string? OtherPrescriptions { get; set; }
    public string? Extra { get; set; }
    public PrescriptionForUpdateDto()
    {

    }
}
