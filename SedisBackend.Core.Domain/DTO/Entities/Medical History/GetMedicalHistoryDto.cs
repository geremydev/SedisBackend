using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Clinical_History;
using SedisBackend.Core.Domain.DTO.Entities.Medical_History.Family_History;

namespace SedisBackend.Core.Domain.DTO.Entities.Medical_History;

public class GetMedicalHistoryDto
{
    public List<ClinicalHistoryDto> ClinicalHistories { get; set; }
    public List<FamilyHistoryDto> FamilyHistories { get; set; }

    // Esto deberia ser con un PatientId, en base a ese se traen alergias, discapacidades y demas del paciente. No la tabla de relacion como tal.

    //public List<BasePatientAllergyDto> PatientAllergies { get; set; }
    //public List<BasePatientDiscapacityDto> PatientDiscapacities { get; set; }
    //public List<BasePatientIllnessDto> PatientIllnesses { get; set; }
    //public List<PatientRiskFactorDto> PatientRiskFactors { get; set; }
}
