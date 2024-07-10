using AsyncAwait.Challenge.Models;

namespace AsyncAwait.Challenge.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetAsync(int id);

    Task SaveAsync(Order order);

    Task DeleteAsync(Order order);
}