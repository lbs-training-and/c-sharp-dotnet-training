using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ToDo.Functions.Models;
using ToDo.Functions.Services;

namespace ToDo.Functions.Functions;

public class CreateToDo
{
    private readonly IToDoService _toDoService;
    private readonly ILogger _logger;

    public CreateToDo(ILoggerFactory loggerFactory, IToDoService toDoService)
    {
        _toDoService = toDoService;
        _logger = loggerFactory.CreateLogger<CreateToDo>();
    }

    [OpenApiOperation(operationId: "createToDo", tags: ["ToDos"], Description = "Creates a given to do item.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(ToDoItem), Required = true, Description = "ToDo item to create.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.Created)]
    [Function("CreateToDo")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "ToDo")] HttpRequestData req,
        FunctionContext executionContext, [FromBody] ToDoItem toDoItemToCreate)
    {
        _toDoService.CreateToDo(toDoItemToCreate);
        
        var response = req.CreateResponse(HttpStatusCode.Created);
        
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        return response;
    }
}