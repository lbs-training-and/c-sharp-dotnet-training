using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using ToDo.Functions.Models;
using ToDo.Functions.Services;
using System.Text.Json;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace ToDo.Functions.Functions;

public class UpdateToDo
{
    private readonly IToDoService _toDoService;
    private readonly ILogger _logger;

    public UpdateToDo(ILoggerFactory loggerFactory, IToDoService toDoService)
    {
        _toDoService = toDoService;
        _logger = loggerFactory.CreateLogger<UpdateToDo>();
    }

    [OpenApiOperation(operationId: "deleteToDo", tags: ["ToDos"], Description = "Updates a given to do item.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(ToDoItem), Required = true, Description = "ToDo item to create.")]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The ID of the to do item.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ToDoItem), Description = "The list of to do item updated.")]
    [Function("Update")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "ToDo/{id}")] HttpRequestData req,
        FunctionContext executionContext, string id, [FromBody] ToDoItem updatedToDoItem)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        
        var responseBody = _toDoService.UpdateToDoItem(updatedToDoItem);
        
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");

        await response.WriteAsJsonAsync(responseBody);
        
        return response;
    }
}