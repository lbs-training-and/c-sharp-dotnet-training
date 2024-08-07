using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using ToDo.Functions.Models;
using ToDo.Functions.Services;

namespace ToDo.Functions.Functions;

public class GetToDos
{
    private readonly IToDoService _toDoService;
    private readonly ILogger _logger;

    public GetToDos(ILoggerFactory loggerFactory, IToDoService toDoService)
    {
        _toDoService = toDoService;
        _logger = loggerFactory.CreateLogger<GetToDos>();
    }

    [OpenApiOperation(operationId: "getToDos", tags: ["ToDos"], Description = "Gets all available to do items.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(IEnumerable<ToDoItem>), Description = "The list of to do items.")]
    [Function("Get")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "ToDo")] HttpRequestData req,
        FunctionContext executionContext)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);

        var responseBody = _toDoService.GetToDos();
        
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        await response.WriteAsJsonAsync(responseBody);

        return response;
    }
}