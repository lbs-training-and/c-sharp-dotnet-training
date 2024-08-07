using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ToDo.Functions;

// public class GetToDos
// {
//     private readonly ILogger<GetToDos> _logger;
//
//     public GetToDos(ILogger<GetToDos> logger)
//     {
//         _logger = logger;
//     }
//
//     [Function("GetToDos")]
//     public IActionResult Run(
//         [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req,
//         FunctionContext context)
//     {
//         _logger.LogInformation("C# HTTP trigger function processed a request.");
//         return new OkObjectResult("Welcome to Azure Functions!");
//     }
// }


public class GetToDos
{
    private readonly ILogger _logger;

    public GetToDos(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<GetToDos>();
    }

    [Function("GetToDos")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        response.WriteString("Welcome to Azure Functions!");

        return response;
    }
}





