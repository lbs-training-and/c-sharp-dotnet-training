using AzureFunction.Challenge.Core.Interfaces;
using AzureFunction.Challenge.Core.Models;
using AzureFunction.Challenge.Core.Models.DTOs;

namespace AzureFunction.Challenge.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<int> CreateOrder(OrderDto orderDto)
        {
            return _orderRepository.SaveOrderAsync(orderDto);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);

            var orderDto = new OrderDto
            {
                DeliveryAddress = result.DeliveryAddress,
                BillingAddress = result.BillingAddress,
                Email = result.Email,
                Phone = result.Phone,
                OrderProducts = result.OrderProducts.Select(orderProduct => new OrderProductDto
                {
                    Quantity = orderProduct.Quantity,
                    Product = new ProductDto
                    {
                        Name = orderProduct.Product.Name,
                        Description = orderProduct.Product.Description,
                        Price = orderProduct.Product.Price
                    },
                    Notes = orderProduct.Notes
                }).ToList()
            };


            return orderDto;
        }
    }
}
