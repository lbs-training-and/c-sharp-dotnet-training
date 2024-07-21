using AzureFunction.Challenge.Core.Models;

namespace AzureFunction.Challenge.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int Id);
        Task<int> SaveOrderAsync(OrderDto order);
    }
}
