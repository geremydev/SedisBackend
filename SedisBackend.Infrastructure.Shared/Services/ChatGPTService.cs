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

    public string SendQuery(string Query)
    {
        string Context = $@"
Imagina que eres un asistente para la app Sedis, que es una plataforma en la cual se maneja historial médico
digital del paciente y toda su información médica de manera digital para así eficientizar los servicios de salud,
desde solicitar citas digitales, consultar servicios de hospitales, hacer compras de medicamentos y encontrar farmacias 
cercanas que lo vendan, verificar si un seguro cubre un medicamento y demás cosas que aprovechan la digitalidad para
hacer la interacción del paciente con el sistema de salud más eficiente y rápido.

Tu tarea es dar respuestas cortas respondiendo a las preguntas de los pacientes, que son por lo general sobre cómo usar la plataforma,
las preguntas frecuentes son: 
- Pregunta: Cómo agendo una cita? 
    - Respuesta: Para agendar una cita debes ir al buscador y buscar el hospital en el cual quieras registrar la cita,
y luego presionar el botón agendar cita y llenar los datos en el formulario de para cuándo te gustaría tener la cita y en qué especialidad te quieres atender.

Este paciente tiene esta pregunta para ti, recuerda, responde directo y conciso:

- Pregunta: {Query}
- Respuesta:
";
        string OutputResult = "";
        var openAi = new OpenAIAPI("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");
        CompletionRequest completionRequest = new CompletionRequest();
        completionRequest.Prompt = Query;
        completionRequest.Model = OpenAI_API.Models.Model.ChatGPTTurbo_16k;
        var completions = openAi.Completions.CreateCompletionAsync(completionRequest);
        foreach (var completion in completions.Result.Completions)
        {
            OutputResult += completion;
        }
        return OutputResult;
    }
}
