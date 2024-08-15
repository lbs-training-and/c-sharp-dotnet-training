using AzureFunction.Challenge.Function.Core.Interfaces;
using AzureFunction.Challenge.Function.Core.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AzureFunction.Challenge.Function
{
    public class BurgerBytesFunction
    {
        private readonly ILogger<BurgerBytesFunction> _logger;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly JsonSerializerOptions _jsonOptions;

        public BurgerBytesFunction(
            ILogger<BurgerBytesFunction> logger,
            IProductService productService,
            IOrderService orderService,
            JsonSerializerOptions jsonOptions)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;
            _jsonOptions = jsonOptions;
        }

        [Function("GetProducts")]
        public async Task<IActionResult> GetProducts(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
        {
            var result = await _productService.GetProductsAsync();
            return new OkObjectResult(result);
        }

        [Function("CreateOrder")]
        public async Task<IActionResult> CreateOrder(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "orders")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var orderDto = JsonSerializer.Deserialize<OrderDto>(requestBody, _jsonOptions);

            if (orderDto is null)
            {
                _logger.LogInformation("Unable to deserialise orderDto {orderDto}", requestBody);
                return new BadRequestObjectResult("Invalid order data.");
            }

            var orderResponse = await _orderService.CreateOrder(orderDto);

            return new OkObjectResult(orderResponse);
        }

        [Function("GetOrder")]
        public async Task<IActionResult> GetOrder(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "orders/{id:int?}")] HttpRequest req,
            int id)
        {
            var result = await _orderService.GetOrderByIdAsync(id);
            return new OkObjectResult(result);
        }
    }
}
