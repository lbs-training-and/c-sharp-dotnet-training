using AzureFunction.Challenge.Function.Core.Models.DTOs;

namespace AzureFunction.Challenge.Function.Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);

        Task<int> CreateOrder(OrderDto orderDto);
    }
}
