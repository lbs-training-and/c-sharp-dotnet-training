using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ToDo.Functions;

public class CreateToDo
{
    private readonly ILogger<CreateToDo> _logger;
    private readonly IToDoService _toDoService;

    public CreateToDo(
        ILogger<CreateToDo> logger,
        IToDoService toDoService)
    {
        _logger = logger;
        _toDoService = toDoService;
    }
    
    [Function("CreateToDo")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
        FunctionContext executionContext,
        [FromBody] OrderDto orderDto)
    {
        await _toDoService.CreateAsync(orderDto);
        
        _logger.LogInformation("Order created.");
        
        var response = req.CreateResponse();

        await response.WriteAsJsonAsync(orderDto);

        return response;
    }
}


