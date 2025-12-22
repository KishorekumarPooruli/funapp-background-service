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

    [Function("ReceiveQueueTrigger")]
    public void Run(
        [QueueTrigger("queue-azure-function", Connection = "AzureWebJobsStorage")]string message)
    {
        _logger.LogInformation("C# Queue trigger function processed: {messageText}", message);
    }
}