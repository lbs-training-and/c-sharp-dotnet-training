using AzureFunction.Challenge.Function.Core.Entities;
using AzureFunction.Challenge.Function.Core.Models.DTOs;

namespace AzureFunction.Challenge.Function.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int Id);
        Task<int> SaveOrderAsync(OrderDto order);
    }
}
