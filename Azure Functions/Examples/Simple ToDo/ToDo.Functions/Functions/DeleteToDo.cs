using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ToDo.Functions.Services;

namespace ToDo.Functions.Functions;

public class DeleteToDo
{
    private readonly IToDoService _toDoService;
    private readonly ILogger _logger;

    public DeleteToDo(ILoggerFactory loggerFactory, IToDoService toDoService)
    {
        _toDoService = toDoService;
        _logger = loggerFactory.CreateLogger<DeleteToDo>();
    }

    [OpenApiOperation(operationId: "updateToDo", tags: ["ToDos"], Description = "Creates a given to do item.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The ID of the to do item.")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NoContent)]
    [Function("DeleteToDo")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "ToDo/{id}")] HttpRequestData req,
        FunctionContext executionContext, string id)
    {
        _toDoService.DeleteToDo(id);

        var response = req.CreateResponse(HttpStatusCode.NoContent);
        
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        
        return response;
    }
}