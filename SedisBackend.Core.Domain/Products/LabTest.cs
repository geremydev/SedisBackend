namespace SedisBackend.Core.Domain.Products
{
    public class LabTest
    {
        public Guid Id { get; set; }

        // Name of the lab test
        public string TestName { get; set; }

        // Code of the lab test (LOINC, CPT, etc.)
        public string TestCode { get; set; }

        //Realizarle la relación de un LabTest es realizado por muchos laboratorios etc etc
    }
}
