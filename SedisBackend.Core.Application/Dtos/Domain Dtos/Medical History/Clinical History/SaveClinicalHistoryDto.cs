using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Doctors;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History
{
    public class SaveClinicalHistoryDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public BasePatientDto Patient { get; set; }
        public int DoctorId { get; set; }
        public BaseDoctorDto Doctor { get; set; }
        public string ReasonForVisit { get; set; }
        public string CurrentHistory { get; set; }
        public string? PhysicalExamination { get; set; }
        public string? Diagnosis { get; set; }

    }
}
