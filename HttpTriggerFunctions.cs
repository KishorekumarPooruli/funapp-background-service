using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace funapp_background_service;

public class HttpTriggerFunctions
{
    private readonly ILogger<HttpTriggerFunctions> _logger;

    public HttpTriggerFunctions(ILogger<HttpTriggerFunctions> logger)
    {
        _logger = logger;
    }


    [Function("Echo")]
    public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("HTTP Trigger Executed Successfully");
        Stream body = req.Body;
        string requestBody = await new StreamReader(body).ReadToEndAsync();
        return new OkObjectResult($"This HTTP triggered function executed successfully. Content: {requestBody}");
    }
}