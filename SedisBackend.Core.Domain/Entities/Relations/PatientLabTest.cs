
using SedisBackend.Core.Domain.Entities.Models.Products;
using SedisBackend.Core.Domain.Entities.Users.Persons;
using SedisBackend.Core.Domain.Medical_History.Clinical_History;

namespace SedisBackend.Core.Domain.Entities.Relations;
public class PatientLabTest : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public Guid? LabTestId { get; set; }
    public LabTest LabTest { get; set; }
    public Guid MedicalConsultationId { get; set; }
    public MedicalConsultation MedicalConsultation { get; set; }



}
