using AzureFunction.Challenge.Core.Models;

namespace AzureFunction.Challenge.Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);

        Task<int> CreateOrder(OrderDto orderDto);
    }
}
