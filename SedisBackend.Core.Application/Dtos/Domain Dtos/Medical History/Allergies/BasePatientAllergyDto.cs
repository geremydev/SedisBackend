using SedisBackend.Core.Application.Dtos.Domain_Dtos.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies
{
    public class BasePatientAllergyDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public BasePatientDto Patient { get; set; }
        public int AllergyId { get; set; }
        public BaseAllergyDto Allergy { get; set; }
        public string AllergicReaction { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
