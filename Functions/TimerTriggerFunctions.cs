using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace funapp_background_service.Functions;

public class TimerTriggerFunctions
{
    private readonly ILogger _logger;

    public TimerTriggerFunctions(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<TimerTriggerFunctions>();
    }

    [Function("RunEvery24Hours")]
    public void Run([TimerTrigger("%DailySchedule%")] TimerInfo myTimer)
    {
        _logger.LogInformation("" +
            "C# Timer trigger function executed at: {executionTime}", DateTime.Now);

        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation("" +
                "Next timer schedule at: {nextSchedule}", myTimer.ScheduleStatus.Next);
        }
    }
}