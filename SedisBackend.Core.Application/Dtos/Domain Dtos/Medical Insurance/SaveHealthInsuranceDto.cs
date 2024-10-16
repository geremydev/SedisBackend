namespace SedisBackend.Core.Application.Dtos.Domain_Dtos.Medical_Insurance
{
    public class SaveHealthInsuranceDto
    {
        public Guid Id { get; set; }
        public string InsuranceName { get; set; }
        public string PolicyType { get; set; } // Usando el enum PolicyType
        public string InsuranceCompany { get; set; }
        public string CoverageLevel { get; set; } // Usando el enum CoverageLevel
    }
}
