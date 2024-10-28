using SedisBackend.Core.Domain.DTO.Entities.Appointments;
using SedisBackend.Core.Domain.DTO.Entities.Health_Centers;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.DTO.Entities.Medical_Specialty;

namespace SedisBackend.Core.Domain.DTO.Entities.Users.Doctors;

public record DoctorDto : BaseUserDto
{
    public string LicenseNumber { get; set; }
    public List<HealthCenterDto> CurrentlyWorkingHealthCenters { get; set; } = new List<HealthCenterDto>();
    public List<MedicalSpecialtyDto> Specialties { get; set; } = new List<MedicalSpecialtyDto>();
    public List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    public List<ClinicalHistoryDto> DevelopedClinicalHistories { get; set; } = new List<ClinicalHistoryDto>();
}
