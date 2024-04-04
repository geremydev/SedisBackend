namespace SedisBackend.Core.Domain.Medical_History.Medical_Conditions.Discapacity_Condition
{
    public class Discapacity
    {
        public int Id { get; set; }

        // Tipo de discapacidad (física, sensorial, intelectual, etc.)
        public string Type { get; set; }

        // Descripción de la discapacidad
        public string Description { get; set; }

    }

}
