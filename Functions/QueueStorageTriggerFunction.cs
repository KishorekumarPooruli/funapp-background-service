using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace funapp_background_service.Functions;

public class QueueStorageTriggerFunction
{
    private readonly ILogger<QueueStorageTriggerFunction> _logger;

    public QueueStorageTriggerFunction(ILogger<QueueStorageTriggerFunction> logger)
    {
        _logger = logger;
    }

    //// [Function("ReceiveQueueTrigger")]
    public void Run(
        [QueueTrigger("queue-azure-function", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message);
    }

    [Function("ReceiveAndSendQueueTrigger")]
    [QueueOutput("queue-azure-function-output")]
    public async Task<string[]> QueueInputOutputFunction(
        [QueueTrigger("queue-azure-function")] string message)
    {
        _logger.LogInformation($"C# Queue trigger function processed: {message} from (queue-azure-function)");
        message = message + "- Processed";
        string[] messages = new string[] { message };
        await Task.Delay(TimeSpan.FromMinutes(1));
        _logger.LogInformation($"C# Queue trigger function processed: {message} to (queue-azure-function-output)");

        // Queue Output messages
        return messages;
    }
}