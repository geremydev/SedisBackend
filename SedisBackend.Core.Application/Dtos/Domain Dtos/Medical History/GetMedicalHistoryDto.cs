using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Allergies;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Clinical_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Family_History;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Discapacity_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Illness_Condition;
using SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History.Medical_Condition.Risk_Factor_Condition;

namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_History
{
    public class GetMedicalHistoryDto
    {
        public List<BaseClinicalHistoryDto> ClinicalHistories { get; set; }
        public List<BaseFamilyHistoryDto> FamilyHistories { get; set; }
        public List<BasePatientAllergyDto> PatientAllergies { get; set; }
        public List<BasePatientDiscapacityDto> PatientDiscapacities { get; set; }
        public List<BasePatientIllnessDto> PatientIllnesses { get; set; }
        public List<BasePatientRiskFactorDto> PatientRiskFactors { get; set; }
    }
}
