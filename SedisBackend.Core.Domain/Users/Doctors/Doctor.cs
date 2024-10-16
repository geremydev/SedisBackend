using SedisBackend.Core.Domain.Appointments;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Users.Doctors
{
    public class Doctor : BasePerson
    {
        public string LicenseNumber { get; set; }
        public ICollection<DoctorHealthCenter> CurrentlyWorkingHealthCenters { get; set; }
        public ICollection<DoctorMedicalSpecialty> Specialties { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<ClinicalHistory> DevelopedClinicalHistories { get; set; }
    }
}
