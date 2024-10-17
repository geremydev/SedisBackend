using SedisBackend.Core.Domain.Prescriptions;
using SedisBackend.Core.Domain.Users.Doctors;
using SedisBackend.Core.Domain.Users.Patients;

namespace SedisBackend.Core.Domain.Medical_History.Clinical_History
{
    public class ClinicalHistory : IBaseEntity
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public string ReasonForVisit { get; set; }
        public string CurrentHistory { get; set; }
        public string? PhysicalExamination { get; set; }
        public string? Diagnosis { get; set; }
        public Guid PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }
        public DateTime RegisterDate { get; set; }


        /* Ejemplo de campos
         HistoriaActual VARCHAR(1000) NOT NULL:

            Función: Almacena la descripción de la historia actual del paciente, tal como la relata durante la consulta médica.
            Contenido: Debe incluir:
            Motivo de la consulta: La razón por la que el paciente acude a la consulta.
            Síntomas: Los síntomas que el paciente está experimentando, incluyendo su severidad, duración y características específicas.
            Enfermedad actual: La historia de la enfermedad actual, incluyendo su evolución, tratamiento recibido y respuesta al mismo.
            Antecedentes médicos: Los antecedentes médicos relevantes del paciente, como enfermedades preexistentes, alergias, medicamentos que toma, etc.
            Hábitos: Hábitos del paciente como tabaquismo, consumo de alcohol, dieta, ejercicio físico, etc.
            Revisión por sistemas: Un resumen de los síntomas y signos relevantes para cada sistema del cuerpo.
        
        ExamenFisico VARCHAR(1000) NOT NULL:

            Función: Almacena los hallazgos del examen físico realizado por el médico durante la consulta.
            Contenido: Debe incluir:
            Signos vitales: Presión arterial, frecuencia cardíaca, frecuencia respiratoria, temperatura corporal.
            Antropometría: Peso, talla, índice de masa corporal.
            Examen general: Estado de la piel, mucosas, cabello, ojos, oídos, nariz, garganta, cuello, ganglios linfáticos, pulmones, corazón, abdomen, extremidades.
            Exámenes específicos: Cualquier examen físico adicional realizado, como palpación, auscultación, percusión, etc.
            Ejemplo de datos:

        Ej:
        HistoriaActual:
            Dolor abdominal de 2 días de evolución, tipo cólico, localizado en la región periumbilical, sin irradiación.
            Náuseas y vómitos en 1 ocasión.
            No fiebre, no diarrea, no estreñimiento.
            Antecedentes de gastritis crónica.
            Toma omeprazol 20 mg al día.
            No fuma, consume alcohol ocasionalmente, dieta balanceada, realiza ejercicio físico 3 veces por semana.
        
        ExamenFisico:
            Signos vitales: PA 120/80 mmHg, FC 80 ppm, FR 16 rpm, T 37°C.
            Antropometría: Peso 70 kg, talla 1.70 m, IMC 24.2 kg/m2.
            Examen general: Piel y mucosas normotensas, cabello y ojos sin alteraciones, ORL sin signos de infección, cuello sin adenopatías.
            Pulmones: Murmullo vesicular conservado, no sibilancias ni roncus.
            Corazón: Ruidos cardíacos rítmicos y regulares, no soplos.
            Abdomen: Blando, depresible, no doloroso a la palpación, no masas ni visceromegalia.
            Extremidades: Sin edemas.
         */
    }
}
