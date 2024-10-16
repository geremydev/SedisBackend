namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Products
{
    public class BaseLabTestDto
    {
        public Guid Id { get; set; }

        // Name of the lab test
        public string TestName { get; set; }

        // Code of the lab test (LOINC, CPT, etc.)
        public string TestCode { get; set; }

    }
}
