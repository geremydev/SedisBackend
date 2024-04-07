using SedisBackend.Core.Domain.Medical_History.Vaccines;
using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Vaccines
{
    public class SavePatientVaccineDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string VaccineId { get; set; }
        public int AppliedDoses { get; set; }
        public DateTime LastApplicationDate { get; set; }
    }
}
