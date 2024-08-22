using BurgerBytes.App.Models;

namespace BurgerBytes.App.Orders;

public interface IOrderManager
{
    IReadOnlyCollection<Order> GetAll();

    void Add(Order order);
}