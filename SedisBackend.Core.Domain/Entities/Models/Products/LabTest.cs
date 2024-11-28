namespace SedisBackend.Core.Domain.Entities.Models.Products;

public class LabTest : IBaseEntity
{
    public Guid Id { get; set; }

    // Name of the lab test
    public string TestName { get; set; }

    // Code of the lab test (LOINC, CPT, etc.)
    public string TestCode { get; set; }
    public bool Status { get; set; }

    //Realizarle la relación de un Appointment es realizado por muchos laboratorios etc etc
}
