using AzureFunction.Challenge.Core.Interfaces;
using AzureFunction.Challenge.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AzureFunction.Challenge
{
    public class BurgerBytesFunction
    {
        private readonly ILogger<BurgerBytesFunction> _logger;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public BurgerBytesFunction(
            ILogger<BurgerBytesFunction> logger,
            IProductService productService,
            IOrderService orderService)
        {
            _logger = logger;
            _productService = productService;
            _orderService = orderService;
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
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var orderDto = JsonSerializer.Deserialize<OrderDto>(requestBody);

                var orderId = await _orderService.CreateOrder(orderDto);

                return new OkObjectResult(new { OrderId = orderId });
            }
            catch (JsonException ex)
            {
                _logger.LogError($"Error deserializing order: {ex.Message}");
                return new BadRequestObjectResult("Invalid JSON format.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating order: {ex.Message}");
                return new StatusCodeResult(500);
            }
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
