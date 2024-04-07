using SedisBackend.Core.Domain.Users.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History
{
    public class SaveFamilyHistoryDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string? RelativeId { get; set; } // Nullable por si el familiar no existe
        public string Condition { get; set; }
        public string Relationship { get; set; } // Relation with the relative (uncle, cousin...)
    }
}
