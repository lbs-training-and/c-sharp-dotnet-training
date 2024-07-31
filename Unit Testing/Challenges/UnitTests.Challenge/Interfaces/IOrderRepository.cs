using UnitTests.Challenge.Models;

namespace UnitTests.Challenge.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetAsync(int id);
    Task SaveAsync(Order order);
    Task DeleteAsync(Order order);
}