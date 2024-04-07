using SedisBackend.Core.Domain.Appointments.Enums;
using SedisBackend.Core.Domain.Health_Centers;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Appointments
{
    public class BaseAppointmentDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int HealthCenterId { get; set; }
        public string AppointmentStatus { get; set; } 
        public string ConsultationType { get; set; } 
        public string ConsultationRoom { get; set; }
    }
}
