using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ToDo.Functions;

// public class UpdateToDo
// {
//     private readonly ILogger<UpdateToDo> _logger;
//     private readonly IToDoService _toDoService;
//
//     public UpdateToDo(
//         ILogger<UpdateToDo> logger,
//         IToDoService toDoService)
//     {
//         _logger = logger;
//         _toDoService = toDoService;
//     }
//     
//     [Function("UpdateToDo")]
//     public async Task<HttpResponseData> Run(
//         [HttpTrigger(AuthorizationLevel.Function, "post", Route = "todo/{id}")] HttpRequestData req,
//         FunctionContext executionContext,
//         int id,
//         [FromBody] OrderDto orderDto)
//     {
//         await _toDoService.UpdateAsync(id, orderDto);
//         
//         _logger.LogInformation("Order updated.");
//         
//         var response = req.CreateResponse();
//
//         await response.WriteAsJsonAsync(orderDto);
//
//         return response;
//     }
// }


