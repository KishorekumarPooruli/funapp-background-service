using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace funapp_background_service.Functions;

public class HttpTriggerFunctions
{
    private readonly ILogger<HttpTriggerFunctions> _logger;
    private readonly IConfiguration _configuration;

    public HttpTriggerFunctions(ILogger<HttpTriggerFunctions> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }


    [Function("Echo")]
    public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        _logger.LogInformation("HTTP Trigger Executed Successfully");
        Stream body = req.Body;
        string requestBody = await new StreamReader(body).ReadToEndAsync();
        return new OkObjectResult($"This HTTP trigger function ({_configuration["FunctionName"]}) executed successfully. Content: {requestBody}");
    }
}