using OpenAI_API;
using OpenAI_API.Completions;
using SedisBackend.Core.Domain.Interfaces.Services.Shared;

namespace SedisBackend.Infrastructure.Shared.Services;

public class ChatGPTService : IChatGPTService
{
    public Task<string> GetChatHistorial()
    {
        throw new NotImplementedException();
    }

    public async Task<string> SendQuery(string query)
    {
        string context = $@"
Imagina que eres un asistente para la app Sedis, que es una plataforma en la cual se maneja historial médico
digital del paciente y toda su información médica de manera digital para así eficientizar los servicios de salud,
desde solicitar citas digitales, consultar servicios de hospitales, hacer compras de medicamentos y encontrar farmacias 
cercanas que lo vendan, verificar si un seguro cubre un medicamento y demás cosas que aprovechan la digitalidad para
hacer la interacción del paciente con el sistema de salud más eficiente y rápido.

Tu tarea es dar respuestas cortas respondiendo a las preguntas de los pacientes, que son por lo general sobre cómo usar la plataforma.
Las preguntas frecuentes son: 
- Pregunta: Cómo agendo una cita? 
    - Respuesta: Para agendar una cita debes ir al buscador y buscar el hospital en el cual quieras registrar la cita,
y luego presionar el botón agendar cita y llenar los datos en el formulario de para cuándo te gustaría tener la cita y en qué especialidad te quieres atender.

Este paciente tiene esta pregunta para ti, recuerda, responde directo y conciso:

- Pregunta: {query}
- Respuesta:
";

        string outputResult = "";

        var openAi = new OpenAIAPI("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");

        var completionRequest = new CompletionRequest
        {
            Prompt = context,
            Model = OpenAI_API.Models.Model.ChatGPTTurbo_16k, // Use a supported model
            MaxTokens = 150, // Adjust based on desired response length
            Temperature = 0.7, // Controls creativity of the response
            TopP = 1.0,
            FrequencyPenalty = 0.0,
            PresencePenalty = 0.0
        };

        var completions = await openAi.Completions.CreateCompletionAsync(completionRequest);

        foreach (var completion in completions.Completions)
        {
            outputResult += completion.Text;
        }

        return outputResult;
    }
}
