using AzureFunction.Challenge.Function.Core.Models.DTOs;

namespace AzureFunction.Challenge.Function.Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);

        Task<OrderResponseDto> CreateOrder(OrderDto orderDto);
    }
}
